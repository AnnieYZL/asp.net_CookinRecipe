using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CookinRecipe.BusinessLayers;
using CookinRecipe.DomainModels;
using CookinRecipe.Web.Models;
using System.Globalization;
using System.Reflection;


namespace CookinRecipe.Web.Controllers
{
	
	public class UserController : Controller
    {
		[Authorize(Roles = $"{WebUserRoles.Administrator},{WebUserRoles.User}")]
		public IActionResult Index()
        {
            long id = long.Parse(User.GetUserData().UserId);
            User user = UserDataService.GetUser(id);
            return View(user);
        }
		[Authorize(Roles = $"{WebUserRoles.Administrator},{WebUserRoles.User}")]
		public IActionResult Edit(User data)
        {
            long id = long.Parse(User.GetUserData().UserId);
            ViewBag.Title = "Chỉnh sửa thông tin";
            var model = UserDataService.GetUser(id);
            if (model == null)
                return RedirectToAction("Index");

            if (string.IsNullOrEmpty(model.UserImage))
                model.UserImage = "nophoto.jpg";

            return View(model);
        }
		public IActionResult UserInfo(long id)
		{
			User user = UserDataService.GetUser(id);
			return View(user);
		}

		[Authorize(Roles = $"{WebUserRoles.Administrator},{WebUserRoles.User}")]
		public IActionResult Save(User data, IFormFile? uploadPhoto)
        {
            ViewBag.Title = "Chỉnh sửa thông tin";

            //Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(data.FullName))
                ModelState.AddModelError(nameof(data.FullName), "Họ tên người dùng không được để trống");
            if (string.IsNullOrWhiteSpace(data.Email))
                ModelState.AddModelError(nameof(data.Email), "Vui lòng nhập email");
            if (string.IsNullOrWhiteSpace(data.Address))
                data.Address = "";

            //Xử lý với ảnh upload (nếu có ảnh upload thì lưu ảnh và gán lại tên file ảnh mới cho employee)
            if (uploadPhoto != null)
            {
                string fileName = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}"; //Tên file sẽ lưu
                string folder = Path.Combine(ApplicationContext.WebRootPath, @"Themes\images\user"); //đường dẫn đến thư mục lưu file
                string filePath = Path.Combine(folder, fileName); //Đường dẫn đến file cần lưu D:\images\employees\photo.png

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    uploadPhoto.CopyTo(stream);
                }
                data.UserImage = fileName;
            }

            if (!ModelState.IsValid)
                return View("Index", data);

            UserDataService.UpdateUser(data);
            return RedirectToAction("Index");
        }

    }
}
