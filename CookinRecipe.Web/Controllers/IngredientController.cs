﻿using CookinRecipe.BusinessLayers;
using CookinRecipe.DomainModels;
using CookinRecipe.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookinRecipe.Web.Controllers
{
    public class IngredientController : Controller
    {
        private const int PAGE_SIZE = 18;
        private const string SEARCH_CONDITION = "ingredient_search"; //Tên biến dùng để lưu trong session
        public IActionResult Index(int page = 1, string searchValue = "", int? ingredientId = null)
        {
            var input = new RecipeByIngredientInput()
            {
                Page = 1,
                PageSize = PAGE_SIZE,
                SearchValue = "",
                ListIngre = new List<int>()
            };
			if (ingredientId.HasValue && ingredientId.Value > 0)
            {
                input.ListIngre.Add(ingredientId.Value);
            }

			return View(input);
        }
        public IActionResult Search(RecipeByIngredientInput input)
        {
            int rowCount = 0;
            List<int> listIng = input.ListIngre;
            List<Ingredient> ds = new List<Ingredient>();
            if (listIng.Count > 0) {
                foreach (int i in listIng)
                {
                    ds.Add(CommonDataService.GetIngredient(i));
                }
            }
            ViewBag.Title = "Nguyên liệu";
            var data = RecipeDataService.GetListRecipeByIngre(listIng);
            var model = new RecipeByIngredient()
            {
                Page = input.Page,
                PageSize = input.PageSize,
                SearchValue = input.SearchValue ?? "",
                RowCount = rowCount,
                Data = data,
                ListIngre = ds
            };
            ApplicationContext.SetSessionData(SEARCH_CONDITION, input);
            return View(model);
        }
    }
}
