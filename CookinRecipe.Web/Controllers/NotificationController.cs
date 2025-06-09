using CookinRecipe.BusinessLayers;
using CookinRecipe.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CookinRecipe.Web.Controllers
{
	[Authorize]
		
	public class NotificationController : Controller
	{
		[HttpPost]
		public IActionResult GetNotifications(long id)
		{
			List<Notification> notiList = CommonDataService.GetListNoti(id);
			Console.WriteLine("Số lượng thông báo: " + notiList.Count);
			Console.WriteLine("ID: " + id);
			return PartialView("_NotificationList", notiList);
		}
	}
}
