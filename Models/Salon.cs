using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Salon
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ad { get; set; }

        [Required]
        [MaxLength(10)]
        public string tur { get; set; } // 'Erkek/Kadın'

        [Required]
        public TimeSpan acilis_saati { get; set; }

        [Required]
        public TimeSpan kapanis_saati { get; set; }

        public ICollection<Calisan> calisanlar { get; set; }
    }

}
