using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

public class AIController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public AIController(IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_configuration["HuggingFace:ApiKey"]}");
    }

    [HttpGet]
    public IActionResult HairRecommendation()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> HairRecommendation(IFormFile photo)
    {
        if (photo != null && photo.Length > 0)
        {
            try
            {
                // Convert image to base64
                using var ms = new MemoryStream();
                await photo.CopyToAsync(ms);
                var imageBytes = ms.ToArray();
                var base64Image = Convert.ToBase64String(imageBytes);

                // Call Hugging Face API
                var apiUrl = "https://api-inference.huggingface.co/models/YOUR_MODEL_HERE";
                var response = await _httpClient.PostAsync(apiUrl, 
                    new StringContent(JsonSerializer.Serialize(new { inputs = base64Image }), 
                    Encoding.UTF8, 
                    "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    ViewBag.Recommendation = result;
                }
                else
                {
                    ViewBag.Recommendation = "Üzgünüz, bir hata oluştu. Lütfen tekrar deneyin.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Recommendation = "Bir hata oluştu: " + ex.Message;
            }
        }

        return View();
    }
}