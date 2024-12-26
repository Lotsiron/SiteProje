using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class KuaforYonetimContext : DbContext
    {
        public KuaforYonetimContext(DbContextOptions options) : base(options) { }

        public DbSet<Salon> kuaforler { get; set; }
        public DbSet<Hizmet> hizmetler { get; set; }
        public DbSet<Calisan> calisanlar { get; set; }
        public DbSet<CalisanHizmet> calisanHizmetler { get; set; }
        public DbSet<CalisanUygunluk> calisanUygunluklar { get; set; }
        public DbSet<Randevu> randevular { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalisanHizmet>()
                .HasIndex(ch => new { ch.CalisanId, ch.HizmetId })
                .IsUnique();
        }
    }
}
