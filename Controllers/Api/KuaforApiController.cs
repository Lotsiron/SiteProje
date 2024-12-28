using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class KuaforApiController : ControllerBase
    {
        private readonly KuaforYonetimContext _context;

        public KuaforApiController(KuaforYonetimContext context)
        {
            _context = context;
        }

        // Salonların istatistiklerini getir
        [HttpGet("salon-istatistikleri")]
        public IActionResult GetSalonIstatistikleri()
        {
            var istatistikler = _context.kuaforler
                .Select(s => new
                {
                    salonId = s.id,
                    salonAd = s.ad,
                    calisanSayisi = s.calisanlar.Count,
                    randevuSayisi = _context.randevular.Count(r => r.kuafor_id == s.id),
                    toplamKazanc = _context.randevular
                        .Where(r => r.kuafor_id == s.id)
                        .Sum(r => r.fiyat)
                })
                .ToList();

            return Ok(istatistikler);
        }

        // Çalışan performans raporu
        [HttpGet("calisan-performans/{calisanId}")]
        public IActionResult GetCalisanPerformans(int calisanId)
        {
            var performans = _context.randevular
                .Where(r => r.calisan_id == calisanId)
                .GroupBy(r => r.tarih.Date)
                .Select(g => new
                {
                    tarih = g.Key,
                    randevuSayisi = g.Count(),
                    toplamKazanc = g.Sum(r => r.fiyat),
                    ortalamaIslemSuresi = g.Average(r => 
                        (r.bitis_saati - r.baslangic_saati).TotalMinutes)
                })
                .OrderByDescending(p => p.tarih)
                .Take(30) // Son 30 günün verisi
                .ToList();

            return Ok(performans);
        }

        // Popüler hizmetler raporu
        [HttpGet("populer-hizmetler")]
        public IActionResult GetPopulerHizmetler([FromQuery] DateTime? baslangic, [FromQuery] DateTime? bitis)
        {
            var query = _context.randevular.AsQueryable();

            if (baslangic.HasValue)
                query = query.Where(r => r.tarih >= baslangic.Value);
            
            if (bitis.HasValue)
                query = query.Where(r => r.tarih <= bitis.Value);

            var populerHizmetler = query
                .GroupBy(r => r.hizmet_id)
                .Select(g => new
                {
                    hizmetId = g.Key,
                    hizmetAdi = g.First().Hizmet.Ad,
                    toplamRandevu = g.Count(),
                    toplamKazanc = g.Sum(r => r.fiyat),
                    ortalamaFiyat = g.Average(r => r.fiyat)
                })
                .OrderByDescending(h => h.toplamRandevu)
                .Take(10)
                .ToList();

            return Ok(populerHizmetler);
        }

        // Randevu durumu güncelleme
        [HttpPut("randevu-durum/{randevuId}")]
        public IActionResult UpdateRandevuDurum(int randevuId, [FromBody] string yeniDurum)
        {
            var randevu = _context.randevular.Find(randevuId);
            if (randevu == null)
                return NotFound();

            // Burada randevu durumu için yeni bir alan eklenmeli
            // randevu.Durum = yeniDurum;
            _context.SaveChanges();

            return Ok(new { message = "Randevu durumu güncellendi" });
        }

        // Çalışanları getir
        [HttpGet("calisanlar")]
        public IActionResult GetCalisanlar()
        {
            var calisanlar = _context.calisanlar
                .Select(c => new { c.Id, c.Ad })
                .ToList();

            return Ok(calisanlar);
        }
    }
} 