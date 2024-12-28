using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Models
{
    public class KuaforYonetimContext : DbContext
    {
        public KuaforYonetimContext(DbContextOptions options) : base(options) { }

        public DbSet<Salon> kuaforler { get; set; }
        public DbSet<Hizmet> hizmetler { get; set; }
        public DbSet<Calisan> calisanlar { get; set; }
        public DbSet<CalisanHizmet> calisan_hizmetler { get; set; }
        public DbSet<CalisanUygunluk> calisan_uygunluk { get; set; }
        public DbSet<Randevu> randevular { get; set; }
        public DbSet<Kullanici> kullanicilar { get; set; }
        public DbSet<Rol> roller { get; set; }

        
    }
}
