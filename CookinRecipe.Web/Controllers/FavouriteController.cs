using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookinRecipe.Web.Controllers
{
	public class FavouriteController : Controller
	{
        [Authorize]
        public IActionResult Index()
		{
			return View();
		}
	}
}
