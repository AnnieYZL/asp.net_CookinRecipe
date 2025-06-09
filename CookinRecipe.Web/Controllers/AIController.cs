using CookinRecipe.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CookinRecipe.Web.Controllers
{
    [Authorize]
    public class AIController : Controller
    {
        private readonly string _apiKey;
        private static string RemoveVietnameseDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            var result = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            result = result.Replace('đ', 'd').Replace('Đ', 'D');

            return result.ToLowerInvariant();
        }
        private static Dictionary<string, string> LoadKeywordReplies()
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/data/keywordReplies.json");
            var jsonString = System.IO.File.ReadAllText(jsonPath);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
            return dictionary ?? new Dictionary<string, string>();
        }

        private static readonly Dictionary<string, string> keywordReplies = LoadKeywordReplies();

        public AIController(IConfiguration configuration)
        {
            _apiKey = configuration["OpenRouter:ApiKey"];
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            var message = request.Message ?? "";

            var normalizedMessage = RemoveVietnameseDiacritics(message).ToLower();

            var match = keywordReplies.FirstOrDefault(kvp =>
            {
                var keyword = RemoveVietnameseDiacritics(kvp.Key).ToLowerInvariant();
                var pattern = $@"\b{Regex.Escape(keyword)}\b";
                return Regex.IsMatch(normalizedMessage, pattern);
            });


            if (!string.IsNullOrEmpty(match.Value))
            {
                return Json(new { reply = match.Value });
            }
            // Nếu không khớp, tiếp tục gửi đến AI
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            client.DefaultRequestHeaders.Add("HTTP-Referer", "https://your-domain.com");
            client.DefaultRequestHeaders.Add("X-Title", "CookinRecipe AI");
            var content = new
            {
                model = "mistralai/mistral-7b-instruct",
                messages = new[]
                {
                new
{
    role = "system",
    content = "Bạn là trợ lý ẩm thực thông minh, trả lời bằng tiếng Việt, ngắn gọn, đúng trọng tâm, chỉ nói về chủ đề món ăn, nấu ăn, nguyên liệu, công thức hoặc ẩm thực. Không nói lan man hoặc lạc chủ đề."
}
,
                new { role = "user", content = request.Message }
            },
            };

            var response = await client.PostAsync("https://openrouter.ai/api/v1/chat/completions",
               new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return Json(new { reply = $"⚠️ Lỗi từ OpenRouter: {response.StatusCode} - {errorContent}" });
            }

            using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            var reply = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

            return Json(new { reply });
        }


    }


}
