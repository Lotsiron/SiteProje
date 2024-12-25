using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RandevuController : Controller
    {
        private readonly ILogger<RandevuController> _logger;

        public RandevuController(ILogger<RandevuController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Salonlar(string salonTur)
        {
            var kuaforler = GetSalonTur(salonTur)

            return View(salons);
        }

        // bazı yerlerde salon bazı yerlerde kuafor olarak geçiyor

        private List<Salon> GetSalonTur(string salonTur)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                // Tipine göre (erkek/kadın) kuaforleri getir

                return dbContext.kuaforler
                                .Where(s => s.Tur == salonTur)
                                .ToList();
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}