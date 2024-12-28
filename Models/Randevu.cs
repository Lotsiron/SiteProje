using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Table("randevular")]
    public class Randevu
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Required]
        [Column("musteri_adi")]
        [MaxLength(100)]
        public string musteri_adi { get; set; }

        [Required]
        [Column("telefon")]
        [MaxLength(15)]
        public string telefon { get; set; }

        [Required]
        [Column("kuafor_id")]
        public int kuafor_id { get; set; }

        [Required]
        [Column("calisan_id")]
        public int calisan_id { get; set; }

        [Required]
        [Column("hizmet_id")]
        public int hizmet_id { get; set; }

        [Required]
        [Column("tarih")]
        public DateTime tarih { get; set; }

        [Required]
        [Column("baslangic_saati")]
        public TimeSpan baslangic_saati { get; set; }

        [Required]
        [Column("bitis_saati")]
        public TimeSpan bitis_saati { get; set; }

        [Required]
        [Column("fiyat")]
        public decimal fiyat { get; set; }

        [Required]
        [Column("durum")]
        [MaxLength(20)]
        public string Durum { get; set; } = "Beklemede";

        [ForeignKey("kuafor_id")]
        public Salon Salon { get; set; }

        [ForeignKey("calisan_id")]
        public Calisan Calisan { get; set; }

        [ForeignKey("hizmet_id")]
        public Hizmet Hizmet { get; set; }
    }
}
