using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RandevuController : Controller
    {
        private readonly ILogger<RandevuController> _logger;
        private readonly KuaforYonetimContext _context;
        public RandevuController(ILogger<RandevuController> logger, KuaforYonetimContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Salonlar(string salonTur)
        {
            var kuaforler = GetSalonTur(salonTur);
            ViewBag.salonTur = salonTur;

            return View(kuaforler);
        }

        // bazı yerlerde salon bazı yerlerde kuafor olarak geçiyor



        // GetSalonTur için fonksiyon
        private List<Salon> GetSalonTur(string salonTur)
        {
            return _context.kuaforler
                        .Where(s => s.tur == salonTur)
                        .ToList();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}