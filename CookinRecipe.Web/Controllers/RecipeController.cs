using CookinRecipe.BusinessLayers;
using CookinRecipe.DomainModels;
using CookinRecipe.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookinRecipe.Web.Controllers
{
	public class RecipeController : Controller
	{
        private const int PAGE_SIZE = 20;
        private const string SEARCH_CONDITION = "recipe_search";
		public IActionResult Index(int page = 1, string searchValue = "")
		{
           RecipeSearchInput? input = ApplicationContext.GetSessionData<RecipeSearchInput>(SEARCH_CONDITION);
            if (input == null)
            {
                input = new RecipeSearchInput()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    SearchValue = searchValue
                };
            }
            return View(input);
        }
        public IActionResult Search(RecipeSearchInput input)
        {
            int rowCount = 0;
            var data = RecipeDataService.List(out rowCount, input.Page, input.PageSize, input.SearchValue ?? "");
            var model = new RecipeSResult()
            {
                Page = input.Page,
                PageSize = input.PageSize,
                SearchValue = input.SearchValue ?? "",
                RowCount = rowCount,
                Data = data
            };
            ApplicationContext.SetSessionData(SEARCH_CONDITION, input);
            return View(model);
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
        [HttpPost]
        public IActionResult Save(Recipe data, IFormFile? uploadPhoto, IFormFile? uploadVideo)
        {
            ViewBag.Title = data.RecipeID == 0 ? "Tạo công thức mới" : "Cập nhật công thức";
            //Kiểm tra dữ liệu đầu vào có hợp lệ hay không => Ghi Task List
            if (string.IsNullOrWhiteSpace(data.RecipeName))
                ModelState.AddModelError(nameof(data.RecipeName), "Tên công thức không được để trống");
            data.Description = data.Description ?? "";
            if(data.PrepTime == 0)
            {
                ModelState.AddModelError(nameof(data.PrepTime), "Thời gian nấu không được để trống");
            }
            if (string.IsNullOrEmpty(data.Serving))
            {
                ModelState.AddModelError(nameof(data.Serving), "Khẩu phần không được để trống");
            }
            //Xử lý với ảnh upload (nếu có ảnh upload thì lưu ảnh và gán lại tên file ảnh mới cho employee)
            if (uploadPhoto != null)
            {
                string fileName = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}"; //Tên file sẽ lưu
                string folder = Path.Combine(ApplicationContext.WebRootPath, @"Themes\images\recipe"); //đường dẫn đến thư mục lưu file
                string filePath = Path.Combine(folder, fileName); //Đường dẫn đến file cần lưu D:\images\products\photo.png

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    uploadPhoto.CopyTo(stream);
                }
                data.RecipeImage = fileName;
            }
            else
            {
                ModelState.AddModelError(nameof(data.RecipeImage), "Phải có 1 hình ảnh của món ăn!");
            }
            if (uploadVideo != null)
            {
                string fileName = $"{DateTime.Now.Ticks}_{uploadVideo.FileName}"; //Tên file sẽ lưu
                string folder = Path.Combine(ApplicationContext.WebRootPath, @"Themes\videos"); //đường dẫn đến thư mục lưu file
                string filePath = Path.Combine(folder, fileName); //Đường dẫn đến file cần lưu D:\images\products\photo.png

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    uploadVideo.CopyTo(stream);
                }
                data.RecipeVideo = fileName;
            }
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
            return RedirectToAction("Index", "User");
        }
    }
}
