﻿using Microsoft.AspNetCore.Mvc;

namespace CookinRecipe.Web.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
