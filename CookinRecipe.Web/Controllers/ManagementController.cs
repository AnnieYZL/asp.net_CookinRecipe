using CookinRecipe.BusinessLayers;
using CookinRecipe.DataLayers.SQLServer;
using CookinRecipe.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CookinRecipe.Web.Controllers
{
    
    public class ManagementController : Controller
	{
        [Authorize(Roles = $"{WebUserRoles.Administrator},{WebUserRoles.Moderator}")]
        public IActionResult Index()
		{
			return View();
		}
        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult Users()
        {
            var data = UserDataService.GetAllUsers();
            return PartialView("_ManageUsers", data);
        }
        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult Recipes()
        {
            var data = RecipeDataService.GetAllRecipes();
            return PartialView("_ManageRecipes", data);
        }

        [HttpPost]
        [Authorize(Roles = $"{WebUserRoles.Administrator},{WebUserRoles.Moderator}")]
        public IActionResult VerifyRecipe([FromBody] Recipe data)
        {
            var admin = User.GetUserData();
            if(UserDataService.GetUser(long.Parse(admin.UserId)).RoleNames == "admin" || UserDataService.GetUser(long.Parse(admin.UserId)).RoleNames == "moderator")
            {
                var result = RecipeDataService.Verify(data);

                if (result)
                {
                    var noti = CommonDataService.AddNotification(new Notification
                    {
                        AdminID = data.AdminID,
                        UserID = data.AuthorID,
                        RecipeID = data.RecipeID,
                        Title = "Công thức đã được phê duyệt",
                        Message = "Công thức " + data.RecipeName + " của bạn đã được phê duyệt bởi quản trị viên " + UserDataService.GetUser(data.AdminID).FullName,
                        Type = "Verified"
                    });
                    return Ok(data);
                }
                else
                {
                    return BadRequest("Có lỗi khi duyệt công thức");
                }
            }
            else return StatusCode(403);
        }


        [HttpPost]
        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult UndoVerifyRecipe([FromBody] Recipe data)
        {
            try
            {
                var user = User.GetUserData();
                var dbUser = UserDataService.GetUser(long.Parse(user.UserId));
                
                if (dbUser.RoleNames == "admin")
                {
                    var result = RecipeDataService.UndoVerify(data);
                    Recipe recipe = RecipeDataService.Get(data.RecipeID);
                    if (result)
                    {
                        var tb = CommonDataService.AddNotification(new Notification
                        {
                            UserID = recipe.AuthorID,
                            RecipeID = recipe.RecipeID,
                            Title = "Hủy phê duyệt",
                            Message = "Quản trị viên " + user.FullName + " đã hủy phê duyệt công thức " + recipe.RecipeName + " của bạn",
                            Type = "UndoVerified"
                        });
                        return Ok(data);
                    }
                    else
                    {
                        return BadRequest("Có lỗi khi hoàn tác duyệt công thức");
                    }
                }
                else return StatusCode(403);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi UndoVerifyRecipe: " + ex.Message);
                return StatusCode(500, "Lỗi xử lý server: " + ex.Message);
            }
        }


        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult Ingredients()
        {
            var user = User.GetUserData();
            if (UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "admin")
            {
                var data = CommonDataService.GetAllIngredient();
                return PartialView("_ManageIngredients", data);
            }
            else return StatusCode(403);
        }
        [HttpGet]
        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult GetIngredient(int id)
        {
            var user = User.GetUserData();
            if (UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "admin")
            {
                var ingredient = CommonDataService.GetIngredient(id);
                if (ingredient == null)
                {
                    return NotFound();
                }
                return Json(ingredient);
            }
            else return StatusCode(403);
        }
        [HttpPost]
        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult UpdateIngredient([FromBody] Ingredient model)
        {
            var user = User.GetUserData();
            if (UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "admin")
            {
                if (ModelState.IsValid)
                {
                    var result = CommonDataService.UpdateIngredient(model);
                    if (result)
                        return Ok();
                }

                return BadRequest("Dữ liệu không hợp lệ");
            }
            else return StatusCode(403);
        }
        [HttpPost]
        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult CreateIngredient([FromBody] Ingredient model)
        {
            var user = User.GetUserData();
            if (UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "admin")
            {
                if (ModelState.IsValid)
                {
                    var result = CommonDataService.AddIngredient(model);
                    if (result > 0)
                        return Ok();
                }

                return BadRequest("Dữ liệu không hợp lệ");
            }
            return StatusCode(403);
        }
        [HttpPost]
        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult DeleteIngredient(int id)
        {
            var user = User.GetUserData();
            if (UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "admin")
            {
                var check = CommonDataService.InUsed(id);
                if (check) return BadRequest("Nguyên liệu đang tồn tại trong công thức khác");
                var result = CommonDataService.DeleteIngredient(id);
                if (result)
                    return Ok();
                else return BadRequest("Dữ liệu không hợp lệ");
            }
            else return StatusCode(403);
        }
        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult Courses()
        {
            var user = User.GetUserData();
            if (UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "admin")
            {
                var data = CommonDataService.GetAllCourse();
                return PartialView("_ManageCourses", data);
            }
            else return StatusCode(403);
        }
        [HttpGet]
        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult GetCourse(int id)
        {
            var user = User.GetUserData();
            if (UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "admin")
            {
                var course = CommonDataService.GetCourse(id);
                if (course == null)
                {
                    return NotFound();
                }
                return Json(course);
            }
            else return StatusCode(403);
        }
        [HttpPost]
        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult UpdateCourse([FromForm] Course model, IFormFile? uploadPhoto)
        {
            var user = User.GetUserData();
            if (UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "admin")
            {
                try
                {
                    if (uploadPhoto != null)
                    {
                        string fileName = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}";
                        string folder = Path.Combine(ApplicationContext.WebRootPath, @"FileUpload\images\course");
                        string filePath = Path.Combine(folder, fileName);

                        // Đảm bảo folder tồn tại
                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            uploadPhoto.CopyTo(stream);
                        }

                        model.CourseImage = fileName;
                    }
                    else
                    {
                        var old = CommonDataService.GetCourse(model.CourseID);
                        if (old != null)
                            model.CourseImage = old.CourseImage;
                    }

                    if (!ModelState.IsValid)
                    {
                        var errors = ModelState.Values.SelectMany(v => v.Errors)
                                                      .Select(e => e.ErrorMessage);
                        return BadRequest("Dữ liệu không hợp lệ: " + string.Join("; ", errors));
                    }

                    var result = CommonDataService.UpdateCourse(model);
                    if (result)
                        return Ok();

                    return BadRequest("Cập nhật thất bại.");
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi ra console hoặc logger nếu có
                    Console.WriteLine("UpdateCourse Error: " + ex.Message);
                    return StatusCode(500, "Lỗi máy chủ: " + ex.Message);
                }
            }
            else return StatusCode(403);
        }


        [HttpPost]
        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult DeleteCourse(int id)
        {
            var user = User.GetUserData();
            if (UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "admin")
            {
                var result = CommonDataService.DeleteCourse(id);
                if (result)
                    return Ok();
                else return BadRequest("Dữ liệu không hợp lệ");
            }
            else return StatusCode(403);
        }
        [Authorize(Roles = $"{WebUserRoles.Administrator}, {WebUserRoles.Moderator}")]
        public IActionResult Verifies()
        {
            var user = User.GetUserData();
            if (UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "admin"|| UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "moderator")
            {
                var data = RecipeDataService.GetAllVerifies();
                return PartialView("_ManageVerifies", data);
            }
            else return StatusCode(403);
        }
        [HttpPost]
        [Authorize(Roles = $"{WebUserRoles.Administrator},{WebUserRoles.Moderator}")]
        public IActionResult SendRecipeNotify([FromBody] Notification model)
        {
            var user = User.GetUserData();
            if (UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "admin" || UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "moderator")
            {
                var data = CommonDataService.AddNotification(model);
                return Ok();
            }
            else return StatusCode(403);
        }
        [HttpPost]
        [Authorize(Roles = $"{WebUserRoles.Administrator}")]
        public IActionResult Decentralisation([FromBody] User model)
        {
            var user = User.GetUserData();
            if (UserDataService.GetUser(long.Parse(user.UserId)).RoleNames == "admin")
            {
                try
                {
                    string quyen = model.RoleNames == "user" ? "Người dùng" : model.RoleNames == "moderator" ? "Người kiểm duyệt" : "Quản trị viên";
                    var admin = User.GetUserData();
                    var data = UserDataService.Decentralisation(model);
                    var noti = CommonDataService.AddNotification(new Notification
                    {
                        UserID = model.UserID,
                        Title = "Phân quyền",
                        Message = $"Quản trị viên {admin.FullName} đã phân quyền {quyen} cho tài khoản của bạn.",
                        Type = "Permission",
                        AdminID = long.Parse(admin.UserId)
                    });
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest("Lỗi: " + ex.Message);
                }
            }
            else return StatusCode(403);
        }

    }
}
