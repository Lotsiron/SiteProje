using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("kuaforler")]
    public class Salon
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("ad")]
        public string ad { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("tur")]
        public string tur { get; set; }

        [Required]
        [Column("acilis_saati")]
        public TimeSpan acilis_saati { get; set; }

        [Required]
        [Column("kapanis_saati")]
        public TimeSpan kapanis_saati { get; set; }

        public ICollection<Calisan> calisanlar { get; set; }
    }

}
