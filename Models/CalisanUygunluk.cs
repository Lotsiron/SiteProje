using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CalisanUygunluk
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Calisan")]
        public int CalisanId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Gun { get; set; } // 'Pazartesi', 'Salı', etc.

        [Required]
        public TimeSpan BaslangicSaati { get; set; }

        [Required]
        public TimeSpan BitisSaati { get; set; }

        public DateTime? GecerlilikTarihiBas { get; set; }
        public DateTime? GecerlilikTarihiSon { get; set; }

        public Calisan Calisan { get; set; }
    }
}
