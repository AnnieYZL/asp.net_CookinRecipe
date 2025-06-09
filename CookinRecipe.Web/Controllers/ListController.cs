using CookinRecipe.BusinessLayers;
using CookinRecipe.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CookinRecipe.Web.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetPostsInList(long listId)
        {
            var posts = ListDataService.GetRecipesOf(listId).Select(r => new {
                r.RecipeID,
                r.RecipeName,
                r.Description,
                r.CreatedAt,
                r.PrepTime,
                r.Serving,
                r.Difficulty,
                r.RecipeImage,
                r.RecipeVideo,
                r.Energy,
                r.AuthorID,
                r.IsVerify,
                r.IsRemove
            }).ToList();
            return Json(posts);
        }
        
        [HttpPost]
        public JsonResult RemoveRecipesFromList([FromBody] RemoveRecipesRequest request)
        {
            try
            {
                var success = ListDataService.DeleteRecipesFromList(request.ListId, request.RecipeIds);
                return Json(new { success });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditList(long listId, string listName, IFormFile imageFile)
        {
            var list = ListDataService.GetList(listId);
            if (list == null)
                return Json(new { success = false, message = "Không tìm thấy bộ sưu tập." });
            list.ListName = listName;
            if (imageFile != null && imageFile.Length > 0)
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "FileUpload", "images", "list");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var fullPath = Path.Combine(folderPath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                list.ListImage = fileName;
            }
            var save = ListDataService.UpdateList(list);

            return Json(new { success = true });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var list = ListDataService.DeleteList(id);
            return Ok(new { message = "Xoá thành công" });
        }


    }
}
