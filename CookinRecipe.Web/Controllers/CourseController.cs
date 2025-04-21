using CookinRecipe.BusinessLayers;
using CookinRecipe.DomainModels;
using CookinRecipe.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookinRecipe.Web.Controllers
{
    public class CourseController : Controller
    {
        private const int PAGE_SIZE = 8;
        private const string SEARCH_CONDITION = "course_search";
        public IActionResult Index(int page = 1, string searchValue="")
        {
            PaginationSearchInput? input = ApplicationContext.GetSessionData<PaginationSearchInput>(SEARCH_CONDITION);
            if (input == null)
            {
                input = new PaginationSearchInput()
                {
                    Page = 1,
                    Size = PAGE_SIZE,
                    SearchValue = searchValue
                };
            }
            return View(input);
        }
        public IActionResult Search(PaginationSearchInput input)
        {
            int rowCount = 0;
            var data = CommonDataService.ListCourse(out rowCount, input.Page, input.Size, input.SearchValue ?? "");
            var model = new CourseSearchResult()
            {
                Page = input.Page,
                PageSize = input.Size,
                SearchValue = input.SearchValue ?? "",
                RowCount = rowCount,
                Data = data
            };
            ApplicationContext.SetSessionData(SEARCH_CONDITION, input);
            return View(model);
        }
            public IActionResult Detail(int courseId = 0)
            {
                var data = RecipeDataService.GetRecipeListByCourse(courseId);
                var course = CommonDataService.GetCourse(courseId);
            if (course == null)
            {
                return RedirectToAction("Index");
            }
            RecipeByCourse result = new RecipeByCourse()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    Data = data,
                    RowCount= data.Count,   
                    Course = course
                };
                return View(result);
            }
    }
}
