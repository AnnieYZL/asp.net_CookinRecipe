using CookinRecipe.BusinessLayers;
using CookinRecipe.DataLayers.SQLServer;
using CookinRecipe.DomainModels;
using CookinRecipe.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static Azure.Core.HttpHeader;

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
        [Authorize]
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
            var tb = CommonDataService.AddNotification(new Notification
            {
                UserID = RecipeDataService.Get(recipeId).AuthorID,
                RecipeID = recipeId,
                Title = "Bạn có 1 thông báo mới",
                Message = userData.FullName + " đã bình luận về công thức " + recipe.RecipeName + " của bạn",
                Type = "Comment"
            });
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
        [Authorize]
        public IActionResult Edit(long id = 0)
        {
            ViewBag.Title = "Cập nhật công thức";
            Recipe? recipe = RecipeDataService.Get(id);
            if (recipe == null)
                return RedirectToAction("Index", "Home");
            return View(recipe);
        }
        [Authorize]
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
        [Authorize]
        public IActionResult Save(List<string> StepList, List<string> NoteList, List<int> IngredientList, List<int> QuantityList, List<int> CourseList, List<string> IngreNoteList, Recipe data, IFormFile? uploadPhoto, IFormFile? uploadVideo)
        {
            ViewBag.Title = data.RecipeID == 0 ? "Tạo công thức mới" : "Cập nhật công thức";
            if (uploadPhoto != null)
            {
                string fileName = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}";
                string folder = Path.Combine(ApplicationContext.WebRootPath, @"FileUpload\images\recipe");
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    uploadPhoto.CopyTo(stream);
                }
                data.RecipeImage = fileName;
            }
            if (uploadVideo != null)
            {
                string fileName = $"{DateTime.Now.Ticks}_{uploadVideo.FileName}";
                string folder = Path.Combine(ApplicationContext.WebRootPath, @"FileUpload\videos");
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    uploadVideo.CopyTo(stream);
                }
                data.RecipeVideo = fileName;
            }
            if (!ModelState.IsValid)
            {
                return View("Edit", data);
            }
            if (data.RecipeID == 0)
            {
                long recipeId = RecipeDataService.Add(data);
                int n = IngredientList.Count;
                if (n == QuantityList.Count && n > 0)
                {
                    List<RecipeIngredient> nl = new List<RecipeIngredient>();
                    for (int i = 0; i < n; i++)
                    {
                        nl.Add(new RecipeIngredient
                        {
                            RecipeID = recipeId,
                            IngredientID = IngredientList[i],
                            Quantity = QuantityList[i],
                            IngreNote = IngreNoteList[i],
                        });
                    }
                    RecipeDataService.AddIngredients(nl);
                }
                if (StepList.Count > 0)
                {
                    int j = 0;
                    for (int i = 0; i < StepList.Count; i++)
                    {
                        if (StepList[i].Trim() != null || StepList[i].Trim() != "")
                        {
                            Step st = new Step
                            {
                                RecipeID = recipeId,
                                StepNumber = j + 1,
                                Description = StepList[i]
                            };
                            RecipeDataService.AddSteps(st);
                            j++;
                        }
                    }

                }
                if (NoteList.Count > 0)
                {
                    int j = 0;
                    for (int i = 0; i < NoteList.Count; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(NoteList[i]))
                        {
                            Note nt = new Note
                            {
                                RecipeID = recipeId,
                                NoteNumber = j + 1,
                                NoteContent = NoteList[i]
                            };
                            RecipeDataService.AddNotes(nt);
                            j++;
                        }
                    }
                }

                if (CourseList.Count > 0)
                {
                    for (int i = 0; i < CourseList.Count; i++)
                    {
                        RecipeDataService.AddRecipeInCourse(CourseList[i], recipeId);
                    }
                }
                RecipeDataService.SetEnergy(recipeId);
                return RedirectToAction("Detail", new { id = recipeId });
            }
            else
            {
                long recipeId = data.RecipeID;
                RecipeDataService.DeleteSteps(recipeId);
                RecipeDataService.DeleteIngredients(recipeId);
                RecipeDataService.DeleteNotes(recipeId);
                RecipeDataService.DeleteRecipeInCourse(recipeId);
                int n = IngredientList.Count;
                if (n == QuantityList.Count && n > 0)
                {
                    List<RecipeIngredient> nl = new List<RecipeIngredient>();
                    for (int i = 0; i < n; i++)
                    {
                        nl.Add(new RecipeIngredient
                        {
                            RecipeID = recipeId,
                            IngredientID = IngredientList[i],
                            Quantity = QuantityList[i],
                            IngreNote = IngreNoteList[i],
                        });
                    }
                    RecipeDataService.AddIngredients(nl);
                }
                if (StepList.Count > 0)
                {
                    int j = 0;
                    for (int i = 0; i < StepList.Count; i++)
                    {
                        if (StepList[i].Trim() != null || StepList[i].Trim() != "")
                        {
                            Step st = new Step
                            {
                                RecipeID = recipeId,
                                StepNumber = j + 1,
                                Description = StepList[i]
                            };
                            RecipeDataService.AddSteps(st);
                            j++;
                        }
                    }

                }
                if (NoteList.Count > 0)
                {
                    int j = 0;
                    for (int i = 0; i < NoteList.Count; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(NoteList[i]))
                        {
                            Note nt = new Note
                            {
                                RecipeID = recipeId,
                                NoteNumber = j + 1,
                                NoteContent = NoteList[i]
                            };
                            RecipeDataService.AddNotes(nt);
                            j++;
                        }
                    }
                }
                if (CourseList.Count > 0)
                {
                    for (int i = 0; i < CourseList.Count; i++)
                    {
                        RecipeDataService.AddRecipeInCourse(CourseList[i], recipeId);
                    }
                }
                RecipeDataService.Update(data);
                RecipeDataService.SetEnergy(recipeId);
                return RedirectToAction("Detail", new { id = recipeId });
            }
        }
        [Authorize]
        public IActionResult Delete(long id = 0)
        {
            RecipeDataService.DeleteList2(id);
            RecipeDataService.DeleteCommentv2(id);
            RecipeDataService.DeleteNotiv2(id);
            RecipeDataService.DeleteFav2(id);
            RecipeDataService.DeleteRate(id);
            RecipeDataService.DeleteNotes(id);
            RecipeDataService.DeleteSteps(id);
            RecipeDataService.DeleteIngredients(id);
            RecipeDataService.DeleteRecipeInCourse(id);
            RecipeDataService.Delete(id);
            return RedirectToAction("Index", "User");
        }
        [HttpPost]
        [Authorize]
        public async Task<JsonResult> CreateList(string listName, IFormFile imageFile)
        {
            try
            {
                var user = User.GetUserData();
                if (user == null || string.IsNullOrWhiteSpace(listName))
                    return Json(new { success = false, message = "Thiếu thông tin" });

                var userId = long.Parse(user.UserId);
                string savedImagePath = null;

                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "FileUpload", "images", "list");
                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(uploadPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    savedImagePath = fileName;
                }

                long newListId = ListDataService.AddList(new List
                {
                    ListName = listName,
                    UserID = userId,
                    ListImage = savedImagePath != null ? savedImagePath : "no-image.png"
                });

                return Json(new { success = true, listId = newListId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }



        [HttpPost]
        [Authorize]
        public JsonResult SaveToList(long recipeId, List<long> listIds)
        {
            try
            {
                var user = User.GetUserData();
                if (user == null)
                    return Json(new { success = false, message = "Chưa đăng nhập" });
                foreach (var listId in listIds)
                {
                    RecipeDataService.AddToList(recipeId, listId);
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Công thức đã được lưu trong danh sách này rồi!" });
            }
        }

        [HttpPost]
        [Authorize]
        public JsonResult RateRecipe(long recipeId, int rating)
        {
            var user = User.GetUserData();
            if (user == null)
                return Json(new { success = false, message = "Bạn cần đăng nhập để đánh giá." });
            try
            {
                if (RatingDataService.CheckExistRate(long.Parse(user.UserId), recipeId) == true)
                {
                    RatingDataService.UpdateRating(new Rating
                    {
                        UserID = long.Parse(user.UserId),
                        RecipeID = recipeId,
                        Point = rating,
                        IsCancel = false
                    });

                }
                else
                {
                    RatingDataService.AddRating(new Rating
                    {
                        UserID = long.Parse(user.UserId),
                        RecipeID = recipeId,
                        Point = rating,
                        IsCancel = false
                    });
                }
                var tb = CommonDataService.AddNotification(new Notification
                {
                    UserID = RecipeDataService.Get(recipeId).AuthorID,
                    RecipeID = recipeId,
                    Title = "Đánh giá công thức",
                    Message = user.FullName + " đã đánh giá " + rating + " sao cho công thức " + RecipeDataService.Get(recipeId).RecipeName + " của bạn",
                    Type = "Rate"
                });
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public JsonResult GetUserRating(long recipeId)
        {
            var user = User.GetUserData();
            if (user == null)
                return Json(new { success = false });

            var rating = RatingDataService.CheckRate(long.Parse(user.UserId), recipeId);
            return Json(new { success = true, rating = rating });
        }

        [HttpPost]
        [Authorize]
        public JsonResult ToggleLike(long id)
        {
            try
            {
                var userData = User.GetUserData();
                if (userData == null) return Json(new { success = false, message = "Người dùng chưa đăng nhập vào hệ thống!" });

                var userId = long.Parse(userData.UserId);

                bool isCancel = FavouriteDataService.AddFav(new Favourite
                {
                    UserID = userId,
                    RecipeID = id,
                });
                if (!isCancel)
                {
                    var tb = CommonDataService.AddNotification(new Notification
                    {
                        UserID = RecipeDataService.Get(id).AuthorID,
                        RecipeID = id,
                        Title = "Yêu thích công thức",
                        Message = userData.FullName + " đã thích công thức " + RecipeDataService.Get(id).RecipeName + " của bạn",
                        Type = "Favourite"
                    });

                }
                return Json(new
                {
                    success = true,
                    isCancel = isCancel,
                    numLikes = RecipeDataService.CountFav(id)
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Exception: " + ex.Message });
            }
        }
    }
}
