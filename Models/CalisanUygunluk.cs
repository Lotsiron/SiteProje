using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Table("calisan_uygunluk")]
    public class CalisanUygunluk
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Calisan")]
        [Column("calisan_id")]
        public int CalisanId { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("gun")]
        public string Gun { get; set; }

        [Required]
        [Column("baslangic_saati")]
        public TimeSpan BaslangicSaati { get; set; }

        [Required]
        [Column("bitis_saati")]
        public TimeSpan BitisSaati { get; set; }

        [Column("gecerlilik_tarihi_bas")]
        public DateTime? GecerlilikTarihiBas { get; set; }

        [Column("gecerlilik_tarihi_son")]
        public DateTime? GecerlilikTarihiSon { get; set; }

        public Calisan Calisan { get; set; }
    }
}
