using CookinRecipe.BusinessLayers;
using CookinRecipe.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using CookinRecipe.DomainModels;

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
        [HttpPost]
        public async Task<IActionResult> SendFeedback(string name, string email, string note)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(note))
            {
                return Json(new { success = false, message = "Vui lòng điền đầy đủ thông tin." });
            }

            try
            {
                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("cookinrecipeuser@gmail.com");
                mailMessage.To.Add("trangdo3009@gmail.com");
                mailMessage.Subject = "Đánh giá mới từ CookinRecipe";
                mailMessage.Body = $"Họ tên: {name}\nEmail: {email}\nNội dung đánh giá:\n{note}";
                mailMessage.IsBodyHtml = false;

                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("cookinrecipeuser@gmail.com", "lufv gjrf uelt wmss");
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;

                    await smtpClient.SendMailAsync(mailMessage);
                }

                return Json(new { success = true, message = "Cảm ơn bạn đã gửi đánh giá!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Lỗi khi gửi đánh giá: " + ex.Message });
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetNotifications(long userId)
        {
            var notifications = CommonDataService.GetListNoti(userId);

            var result = notifications.Select(x => new
            {
                notificationId = x.NotificationID,
                recipeId = x.RecipeID,
                title = x.Title,
                message = x.Message,
                type = x.Type,
                createdAt = x.CreatedAt.ToString("dd/MM/yyyy"),
                isRead = x.IsRead
            });

            var unreadCount = CommonDataService.CountUnread(userId);

            return Json(new
            {
                items = result,
                unread = unreadCount
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult MarkNotificationRead([FromBody] NotificationIdModel model)
        {
            if (model == null || model.Id <= 0)
                return BadRequest("Dữ liệu không hợp lệ.");

            var success = CommonDataService.ReadNoti(model.Id);
            return success ? Ok() : StatusCode(500, "Không cập nhật được trạng thái.");
        }



    }
}
