using CookinRecipe.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookinRecipe.Web.Controllers
{
	public class AIController : Controller
	{
		private readonly string apiKey = "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";

		[HttpPost]
		public async Task<IActionResult> Chat([FromBody] ChatRequest request)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

			var content = new
			{
				model = "gpt-3.5-turbo",
				messages = new[] {
				new { role = "system", content = "Bạn là trợ lý ẩm thực thông minh, trả lời ngắn gọn, thân thiện." },
				new { role = "user", content = request.Message }
			},
				max_tokens = 150
			};

			var response = await client.PostAsync("https://api.openai.com/v1/chat/completions",
				new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json"));

			var responseJson = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode)
			{
				var errorContent = await response.Content.ReadAsStringAsync();
				if ((int)response.StatusCode == 429)
				{
					return Json(new { reply = "⚠️ API OpenAI đã vượt hạn mức sử dụng. Vui lòng kiểm tra quota hoặc chờ một thời gian." });
				}
				return Json(new { reply = $"⚠️ Lỗi từ OpenAI: {response.StatusCode} - {errorContent}" });
			}

			using var doc = JsonDocument.Parse(responseJson);
			var reply = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

			return Json(new { reply });
		}
	}
}
