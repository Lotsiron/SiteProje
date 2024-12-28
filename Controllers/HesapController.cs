using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    public class HesapController : Controller
    {
        private readonly KuaforYonetimContext _context;

        public HesapController(KuaforYonetimContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var kullanici = _context.kullanicilar
                .Include(k => k.Rol)
                .FirstOrDefault(k => k.Email == model.Email && k.Sifre == model.Sifre);

            if (kullanici == null)
                return Json(new { success = false, message = "Email veya şifre hatalı" });

            Console.WriteLine($"Kullanıcı Rolü: {kullanici.Rol?.Ad}");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, kullanici.Id.ToString()),
                new Claim(ClaimTypes.Name, kullanici.Ad),
                new Claim(ClaimTypes.Role, kullanici.Rol?.Ad ?? "")
            };

            Console.WriteLine($"Claimler: {string.Join(", ", claims.Select(c => $"{c.Type}: {c.Value}"))}");

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
                // cookie süresi 1 gün
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            // Session verileri korunuyor(eski kodlardan dolayı)
            HttpContext.Session.SetInt32("UserId", kullanici.Id);
            HttpContext.Session.SetString("UserRole", kullanici.Rol.Ad);
            HttpContext.Session.SetString("UserName", kullanici.Ad);

            return Json(new { success = true, redirectUrl = "/" });
        }

        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kayit([FromBody] Kullanici kullanici)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    return Json(new { success = false, message = string.Join(", ", errors) });
                }

                // Email zaten kayıtlı mı kontrolü
                if (_context.kullanicilar.Any(k => k.Email == kullanici.Email))
                {
                    return Json(new { success = false, message = "Bu email adresi zaten kayıtlı." });
                }

                // Kullanıcı rolünü belirle
                kullanici.RolId = 3; // Kullanici rol
                kullanici.OlusmaTarihi = DateTime.Now;

                _context.kullanicilar.Add(kullanici);
                _context.SaveChanges();

                return Json(new { success = true, message = "Kayıt başarıyla tamamlandı." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Kayıt işlemi sırasında bir hata oluştu: " + ex.Message });
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ErisimReddedildi()
        {
            return View();
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Sifre { get; set; }
    }
}