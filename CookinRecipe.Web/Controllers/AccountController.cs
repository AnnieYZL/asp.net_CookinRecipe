using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CookinRecipe.BusinessLayers;
using CookinRecipe.DomainModels;
using BCrypt.Net;
using CookinRecipe.Web;
using CookinRecipe.Web.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authentication.Google;
using System.Security.Claims;


namespace CookinRecipe.Web.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		[AllowAnonymous]
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Register(string fullname, string email, string password, string confirm_password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fullname) || string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirm_password))
                {
                    return Json(new { status = "error", message = "Vui lòng điền đầy đủ thông tin." });
                }

                if (password != confirm_password)
                {
                    return Json(new { status = "error", message = "Mật khẩu xác nhận không khớp." });
                }

                if (UserDataService.GetAllUsers().Any(u => u.Email == email))
                {
                    return Json(new { status = "error", message = "Email đã được sử dụng." });
                }

                var user = new UserAccount
                {
                    FullName = fullname,
                    Email = email,
                    Password = BCrypt.Net.BCrypt.HashPassword(password),
                };
                UserAccountService.CreateAccount(user);

                return Json(new { status = "success", message = "Tạo tài khoản thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = "Đã xảy ra lỗi: " + ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            ViewBag.Email = email;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return Json(new { success = false, message = "Vui lòng nhập đầy đủ thông tin đăng nhập." });
            }

            var userAccount = UserAccountService.AuthorizeByEmail(email);
            if (userAccount == null)
            {
                return Json(new { success = false, message = "Email này chưa đăng ký tài khoản" });
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, userAccount.Password);
            if (!isPasswordValid)
            {
                return Json(new { success = false, message = "Email hoặc mật khẩu không đúng." });
            }
            var userData = new WebUserData()
            {
                UserId = userAccount.UserID,
                FullName = userAccount.FullName,
                Email = userAccount.Email,
                UserImage = userAccount.UserImage,
                ClientIP = HttpContext.Connection.RemoteIpAddress?.ToString(),
                SessionId = HttpContext.Session.Id,
                AdditionalData = "",
                Roles = userAccount.RoleNames.Split(',').ToList()
            };
            await HttpContext.SignInAsync(userData.CreatePrincipal());
            return Json(new { success = true, message = "Đăng nhập thành công!" });
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string userName = "", string oldPassword = "", string newPassword = "", string confirmPassword = "")
        {
            // Lưu lại các giá trị đã nhập để trả lại view nếu có lỗi
            ViewBag.oldPassword = oldPassword;
            ViewBag.newPassword = newPassword;
            ViewBag.confirmPassword = confirmPassword;

            if (string.IsNullOrWhiteSpace(oldPassword))
            {
                TempData["ErrorMessage"] = "Vui lòng nhập mật khẩu hiện tại!";
                return View();
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                TempData["ErrorMessage"] = "Vui lòng nhập mật khẩu mới!";
                return View();
            }

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                TempData["ErrorMessage"] = "Bạn phải xác nhận mật khẩu!";
                return View();
            }

            if (newPassword != confirmPassword)
            {
                TempData["ErrorMessage"] = "Mật khẩu xác nhận không đúng!";
                return View();
            }

            bool isChangePassword = UserAccountService.ChangePassword(userName, oldPassword, newPassword);
            if (!isChangePassword)
            {
                TempData["ErrorMessage"] = "Mật khẩu hiện tại không chính xác!";
                return View();
            }

            TempData["SuccessMessage"] = "Đổi mật khẩu thành công. Bạn cần đăng nhập lại!";
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action("GoogleCallback", "Account");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            Console.WriteLine("==== Redirecting to Google Login ====");
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GoogleCallback()
        {
            var claims = HttpContext.User.Identities.FirstOrDefault()?.Claims;
            var email = HttpContext.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login");

            var userAccount = UserAccountService.AuthorizeByEmail(email);
            if (userAccount == null)
            {
                var newUser = new UserAccount
                {
                    Email = email,
                    FullName = name,
                    Password = ""
                };
                UserAccountService.CreateAccount(newUser);
                userAccount = newUser;
            }

            var userData = new WebUserData
            {
                UserId = userAccount.UserID,
                FullName = userAccount.FullName,
                Email = userAccount.Email,
                UserImage = userAccount.UserImage,
                ClientIP = HttpContext.Connection.RemoteIpAddress?.ToString(),
                SessionId = HttpContext.Session.Id,
                AdditionalData = "",
                Roles = userAccount.RoleNames.Split(',').ToList()
            };

            await HttpContext.SignInAsync(userData.CreatePrincipal());
            return RedirectToAction("Index", "Home");
        }



    }
}
