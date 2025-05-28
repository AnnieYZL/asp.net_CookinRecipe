using CookinRecipe.BusinessLayers;
using CookinRecipe.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace CookinRecipe.Web.Controllers
{
	public class ManagementController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Users()
        {
            var data = UserDataService.GetAllUsers();
            return PartialView("_ManageUsers", data);
        }
        public IActionResult Recipes()
        {
            var data = RecipeDataService.GetAllRecipes();
            return PartialView("_ManageRecipes", data);
        }

        [HttpPost]
        public IActionResult VerifyRecipe([FromBody] Recipe data)
        {
            var result = RecipeDataService.Verify(data);

            if (result)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("Có lỗi khi duyệt công thức");
            }
        }


        [HttpPost]
        public IActionResult UndoVerifyRecipe([FromBody] Recipe data)
        {
            var result = RecipeDataService.UndoVerify(data);

            if (result)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("Có lỗi khi hoàn tác duyệt công thức");
            }
        }

        //[HttpPost]
        //public IActionResult DeletePost(string postId)
        //{
        //    PostDataService.Delete(postId);
        //    return Ok();
        //}
        public IActionResult Ingredients()
        {
            var data = CommonDataService.GetAllIngredient();
            return PartialView("_ManageIngredients", data);
        }
        [HttpGet]
        public IActionResult GetIngredient(int id)
        {
            var ingredient = CommonDataService.GetIngredient(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Json(ingredient);
        }
        [HttpPost]
        public IActionResult UpdateIngredient([FromBody] Ingredient model)
        {
            if (ModelState.IsValid)
            {
                var result = CommonDataService.UpdateIngredient(model);
                if (result)
                    return Ok();
            }

            return BadRequest("Dữ liệu không hợp lệ");
        }
        [HttpPost]
        public IActionResult CreateIngredient([FromBody] Ingredient model)
        {
            if (ModelState.IsValid)
            {
                var result = CommonDataService.AddIngredient(model);
                if (result>0)
                    return Ok();
            }

            return BadRequest("Dữ liệu không hợp lệ");
        }
        //[HttpPost]
        //public IActionResult DeleteIngredient(string id)
        //{
        //    IngredientDataService.Delete(id);
        //    return Ok();
        //}
        public IActionResult Courses()
        {
            var data = CommonDataService.GetAllCourse();
            return PartialView("_ManageCourses", data);
        }

        //[HttpPost]
        //public IActionResult DeleteMenu(string id)
        //{
        //    MenuDataService.Delete(id);
        //    return Ok();
        //}
        public IActionResult Verifies()
        {
            var data = RecipeDataService.GetAllVerifies();
            return PartialView("_ManageVerifies", data);
        }
    }
}
