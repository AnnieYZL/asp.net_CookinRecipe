using CookinRecipe.BusinessLayers;
using Microsoft.AspNetCore.Mvc;

namespace CookinRecipe.Web.Controllers
{
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
        public JsonResult DeleteRecipesFromList([FromBody] DeletePostsRequest request)
        {
            foreach (var recipeId in request.RecipeIds)
            {
                RecipeDataService.DeleteFromList(request.ListId, recipeId);
            }

            return Json(new { success = true });
        }

        public class DeletePostsRequest
        {
            public List<long> RecipeIds { get; set; }
            public long ListId { get; set; }
        }


    }
}
