using CookinRecipe.BusinessLayers;
using CookinRecipe.DomainModels;
using CookinRecipe.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookinRecipe.Web.Controllers
{
	public class RecipeController : Controller
	{
		[HttpPost]
		public IActionResult Index(long id = 0)
		{
			return View();
		}
		public IActionResult Detail(long id = 0)
		{
			var recipe = RecipeDataService.Get(id);
			if (recipe == null)
			{
				return RedirectToAction("Index");
			}
			ViewBag.Title = recipe.RecipeName;
			var ingredient = RecipeDataService.ListIngredients(id);
			var step = RecipeDataService.ListSteps(id);
			var note = RecipeDataService.ListNotes(id);
			int rowCount = 0;
			var comment = CommentDataService.ListComment(out rowCount, id, 1, 0);
			var model = new RecipeDetailModel()
			{
				Recipe = recipe,
				Ingredients = ingredient,
				Steps = step,
				Notes = note,
				Comments = comment,
				RowCount = rowCount
			};
			return View(model);
		}
		public IActionResult CreateComment(string newComment = "", long recipeId = 0)
		{
			var userData = User.GetUserData();
			Comment cmt = new Comment()
			{
				CommentContent = newComment,
				UserID = long.Parse(userData.UserId),
				RecipeID = recipeId
			};
			int n = CommentDataService.AddComment(cmt);
            var recipe = RecipeDataService.Get(recipeId);
            if (recipe == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Title = recipe.RecipeName;
            var ingredient = RecipeDataService.ListIngredients(recipeId);
            var step = RecipeDataService.ListSteps(recipeId);
            var note = RecipeDataService.ListNotes(recipeId);
            int rowCount = 0;
            var comment = CommentDataService.ListComment(out rowCount, recipeId, 1, 0);
            var model = new RecipeDetailModel()
            {
                Recipe = recipe,
                Ingredients = ingredient,
                Steps = step,
                Notes = note,
                Comments = comment,
                RowCount = rowCount
            };
            return View("Detail", model);
		}
		public IActionResult Edit(long id = 0)
		{
            ViewBag.Title = "Cập nhật công thức";
            Recipe? recipe = RecipeDataService.Get(id);
            if (recipe == null)
                return RedirectToAction("Index", "Home");
            return View(recipe); 
		}
		public IActionResult Create()
		{
            ViewBag.Title = "Tạo công thức mới";
            Recipe recipe = new Recipe()
            {
				RecipeID = 0
            };
            return View("Edit", recipe);
		}
        public IActionResult Save(Recipe data)
        {
            ViewBag.Title = data.RecipeID == 0 ? "Tạo công thức mới" : "Cập nhật công thức";
            //Kiểm tra dữ liệu đầu vào có hợp lệ hay không => Ghi Task List
            if (string.IsNullOrWhiteSpace(data.RecipeName))
                ModelState.AddModelError(nameof(data.RecipeName), "Tên công thức không được để trống");
            data.Description = data.Description ?? "";
            //Nếu tồn tại lỗi => Trả về view để người sd nhập lại cho đúng
            if (!ModelState.IsValid)
            {
                return View("Edit", data);
            }

            //Gọi chức năng xử lý dưới tầng tác nghiệp nếu quá trình kiểm soát lỗi không phát hiện lỗi đầu vào
            if (data.RecipeID == 0)
            {
                RecipeDataService.Add(data);
            }
            else
            {
                RecipeDataService.Update(data);
            }
            return RedirectToAction("Detail");
        }
        public IActionResult Delete(long id = 0)
        {
            RecipeDataService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
