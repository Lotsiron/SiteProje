using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult GetSalonDetails(int id)
        {
            var salonDetails = _context.kuaforler
                .Include(s => s.calisanlar)
                    .ThenInclude(c => c.CalisanHizmetler)
                        .ThenInclude(ch => ch.Hizmet)
                .FirstOrDefault(s => s.id == id);

            if (salonDetails == null)
                return NotFound();

            // Create a simplified object without circular references
            var result = new
            {
                salon = new
                {
                    salonDetails.id,
                    salonDetails.ad,
                    salonDetails.tur,
                    salonDetails.acilis_saati,
                    salonDetails.kapanis_saati
                },
                calisanlar = salonDetails.calisanlar.Select(c => new
                {
                    c.Id,
                    c.Ad,
                    c.Uzmanlik,
                    hizmetler = c.CalisanHizmetler.Select(ch => new
                    {
                        ch.Hizmet.Id,
                        ch.Hizmet.Ad,
                        ch.Hizmet.Fiyat,
                        ch.Hizmet.Sure
                    }).ToList()
                }).ToList()
            };

            return Json(result);
        }

        [HttpGet]
        public IActionResult RandevuOlustur(int salonId, int calisanId, int hizmetId)
        {
            var calisan = _context.calisanlar
                .Include(c => c.CalisanUygunluklar)
                .Include(c => c.Salon)
                .FirstOrDefault(c => c.Id == calisanId);

            if (calisan == null)
                return NotFound();

            var hizmet = _context.hizmetler.Find(hizmetId);
            if (hizmet == null)
                return NotFound();

            // Get existing appointments for the selected employee
            var mevcutRandevular = _context.randevular
                .Where(r => r.calisan_id == calisanId && r.tarih.Date >= DateTime.Today)
                .OrderBy(r => r.tarih)
                .ThenBy(r => r.baslangic_saati)
                .ToList();

            var viewModel = new RandevuOlusturViewModel
            {
                Calisan = calisan,
                Hizmet = hizmet,
                MevcutRandevular = mevcutRandevular
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RandevuOlustur([FromBody] RandevuCreateModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.musteri_adi))
                    return BadRequest(new { success = false, message = "Müşteri adı boş olamaz" });

                if (string.IsNullOrEmpty(model.telefon))
                    return BadRequest(new { success = false, message = "Telefon numarası boş olamaz" });

                if (!ModelState.IsValid)
                    return BadRequest(new { success = false, message = "Geçersiz veri" });

                var hizmet = _context.hizmetler.Find(model.hizmet_id);
                if (hizmet == null)
                    return NotFound(new { success = false, message = "Hizmet bulunamadı" });

                var bitisSaati = model.baslangic_saati.Add(TimeSpan.FromMinutes(hizmet.Sure));

                var randevu = new Randevu
                {
                    musteri_adi = model.musteri_adi.Trim(),
                    telefon = model.telefon.Trim(),
                    kuafor_id = model.kuafor_id,
                    calisan_id = model.calisan_id,
                    hizmet_id = model.hizmet_id,
                    tarih = model.tarih,
                    baslangic_saati = model.baslangic_saati,
                    bitis_saati = bitisSaati,
                    fiyat = hizmet.Fiyat
                };

                _context.randevular.Add(randevu);
                _context.SaveChanges();

                return Json(new { success = true, message = "Randevu başarıyla oluşturuldu" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Randevu oluşturulamadı: " + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetUygunSaatler(int calisanId, DateTime tarih)
        {
            var calisan = _context.calisanlar
                .Include(c => c.CalisanUygunluklar)
                .Include(c => c.Salon)
                .FirstOrDefault(c => c.Id == calisanId);

            if (calisan == null)
                return NotFound();

            // Get employee availability for the selected day
            var gunAdi = tarih.ToString("dddd", new System.Globalization.CultureInfo("tr-TR"));
            var uygunluk = calisan.CalisanUygunluklar
                .FirstOrDefault(u => u.Gun.ToLower() == gunAdi.ToLower());

            if (uygunluk == null)
                return Json(new List<TimeSpan>());

            // Get existing appointments for that day
            var mevcutRandevular = _context.randevular
                .Where(r => r.calisan_id == calisanId && r.tarih.Date == tarih.Date)
                .OrderBy(r => r.baslangic_saati)
                .ToList();

            // Generate available time slots
            var uygunSaatler = GenerateTimeSlots(uygunluk.BaslangicSaati, 
                                               uygunluk.BitisSaati, 
                                               mevcutRandevular);

            return Json(uygunSaatler);
        }

        private List<TimeSpan> GenerateTimeSlots(TimeSpan start, TimeSpan end, List<Randevu> existingAppointments)
        {
            var slots = new List<TimeSpan>();
            var current = start;
            var slotDuration = TimeSpan.FromMinutes(30); // 30-minute slots

            while (current.Add(slotDuration) <= end)
            {
                bool isAvailable = !existingAppointments.Any(r => 
                    (current >= r.baslangic_saati && current < r.bitis_saati) ||
                    (current.Add(slotDuration) > r.baslangic_saati && current.Add(slotDuration) <= r.bitis_saati));

                if (isAvailable)
                {
                    slots.Add(current);
                }

                current = current.Add(slotDuration);
            }

            return slots;
        }
    }
}
       