using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Randevu
    {
        [Key]
        public int id { get; set; }

        [Required]
        [ForeignKey("Kuafor")]
        public int kuafor_id { get; set; }

        [Required]
        [ForeignKey("Calisan")]
        public int calisan_id { get; set; }

        [Required]
        [ForeignKey("Hizmet")]
        public int hizmet_id { get; set; }

        [Required]
        public DateTime tarih { get; set; }

        [Required]
        public TimeSpan baslangic_saati { get; set; }

        [Required]
        public TimeSpan bitis_saati { get; set; }

        [Required]
        public decimal fiyat { get; set; }

        public Salon Salon { get; set; }
        public Calisan Calisan { get; set; }
        public Hizmet Hizmet { get; set; }

    }
}
