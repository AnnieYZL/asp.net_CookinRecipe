using CookinRecipe.BusinessLayers;
using CookinRecipe.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CookinRecipe.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var top8 = RecipeDataService.GetNewestRecipe();
            if (top8 == null)
            {
                return NotFound();
            }
            return View(top8);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
