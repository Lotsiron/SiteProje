using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly KuaforYonetimContext _context;

        public AdminController(KuaforYonetimContext context)
        {
            _context = context;
        }

        // Ana sayfa
        public IActionResult Index()
        {
            var viewModel = new AdminPanelViewModel
            {
                ToplamSalon = _context.kuaforler.Count(),
                ToplamRandevu = _context.randevular.Count(),
                ToplamKullanici = _context.kullanicilar.Count(),
                SonRandevular = _context.randevular
                    .Include(r => r.Salon)
                    .Include(r => r.Calisan)
                    .Include(r => r.Hizmet)
                    .OrderByDescending(r => r.tarih)
                    .Take(5)
                    .ToList()
            };

            return View(viewModel);
        }

        // Salonları listele
        public IActionResult Salonlar()
        {
            var salonlar = _context.kuaforler
                .Include(s => s.calisanlar)
                .ToList();
            return View(salonlar);
        }

        // Randevuları listele
        public IActionResult Randevular()
        {
            var randevular = _context.randevular
                .Include(r => r.Salon)
                .Include(r => r.Calisan)
                .Include(r => r.Hizmet)
                .OrderByDescending(r => r.tarih)
                .ToList();
            return View(randevular);
        }

        [HttpGet]
        public IActionResult CalisanYonetimi()
        {
            var calisanlar = _context.calisanlar
                .Include(c => c.Salon)
                .Include(c => c.CalisanHizmetler)
                    .ThenInclude(ch => ch.Hizmet)
                .ToList();
            
            ViewBag.Salonlar = _context.kuaforler.ToList();
            ViewBag.Hizmetler = _context.hizmetler.ToList();
            return View(calisanlar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CalisanEkle([FromBody] CalisanEkleModel model)
        {
            try
            {
                if (model == null || string.IsNullOrEmpty(model.Ad))
                    return Json(new { success = false, message = "Geçersiz veri" });

                var calisan = new Calisan
                {
                    Ad = model.Ad,
                    KuaforId = model.SalonId,
                };

                _context.calisanlar.Add(calisan);
                _context.SaveChanges();

                // Seçilen hizmetleri ekle
                if (model.HizmetIds != null && model.HizmetIds.Any())
                {
                    foreach (var hizmetId in model.HizmetIds)
                    {
                        _context.calisan_hizmetler.Add(new CalisanHizmet
                        {
                            CalisanId = calisan.Id,
                            HizmetId = hizmetId
                        });
                    }
                    _context.SaveChanges();
                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult CalisanGuncelle([FromBody] CalisanEkleModel model)
        {
            try
            {
                var calisan = _context.calisanlar
                    .Include(c => c.CalisanHizmetler)
                    .FirstOrDefault(c => c.Id == model.Id);

                if (calisan == null)
                    return Json(new { success = false, message = "Çalışan bulunamadı" });

                calisan.Ad = model.Ad;
                calisan.KuaforId = model.SalonId;

                // Mevcut hizmetleri temizle
                _context.calisan_hizmetler.RemoveRange(calisan.CalisanHizmetler);

                // Yeni hizmetleri ekle
                if (model.HizmetIds != null && model.HizmetIds.Any())
                {
                    foreach (var hizmetId in model.HizmetIds)
                    {
                        _context.calisan_hizmetler.Add(new CalisanHizmet
                        {
                            CalisanId = calisan.Id,
                            HizmetId = hizmetId
                        });
                    }
                }

                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete]
        public IActionResult CalisanSil(int id)
        {
            try
            {
                var calisan = _context.calisanlar.Find(id);
                if (calisan == null)
                    return Json(new { success = false, message = "Çalışan bulunamadı" });

                _context.calisanlar.Remove(calisan);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult HizmetYonetimi()
        {
            var hizmetler = _context.hizmetler.ToList();
            return View(hizmetler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HizmetEkle([FromBody] Hizmet hizmet)
        {
            try
            {
                if (hizmet == null || string.IsNullOrEmpty(hizmet.Ad))
                    return Json(new { success = false, message = "Geçersiz veri" });

                // Model durumunu kontrol et
                if (!ModelState.IsValid)
                {
                    var errors = string.Join(", ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    return Json(new { success = false, message = errors });
                }

                _context.hizmetler.Add(hizmet);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult HizmetGuncelle([FromBody] Hizmet hizmet)
        {
            try
            {
                var mevcutHizmet = _context.hizmetler.Find(hizmet.Id);
                if (mevcutHizmet == null)
                    return Json(new { success = false, message = "Hizmet bulunamadı" });

                mevcutHizmet.Ad = hizmet.Ad;
                mevcutHizmet.Fiyat = hizmet.Fiyat;
                mevcutHizmet.Sure = hizmet.Sure;

                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete]
        public IActionResult HizmetSil(int id)
        {
            try
            {
                var hizmet = _context.hizmetler.Find(id);
                if (hizmet == null)
                    return Json(new { success = false, message = "Hizmet bulunamadı" });

                _context.hizmetler.Remove(hizmet);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RandevuDurumGuncelle([FromBody] RandevuDurumModel model)
        {
            try
            {
                if (model == null)
                    return Json(new { success = false, message = "Geçersiz veri" });

                var randevu = _context.randevular.Find(model.randevuId);
                if (randevu == null)
                    return Json(new { success = false, message = "Randevu bulunamadı" });

                randevu.Durum = model.durum;
                _context.SaveChanges();

                return Json(new { success = true, message = "Durum güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // Controller sınıfının içinde model sınıfını tanımlayın
        public class RandevuDurumModel
        {
            public int randevuId { get; set; }
            public string durum { get; set; }
        }

        public class CalisanEkleModel
        {
            public int Id { get; set; }
            public string Ad { get; set; }
            public int SalonId { get; set; }
            public List<int> HizmetIds { get; set; }
        }
    }
} 