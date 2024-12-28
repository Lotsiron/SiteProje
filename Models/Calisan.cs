using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Table("calisanlar")]
    public class Calisan
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("ad")]
        public string Ad { get; set; }

        [Column("uzmanlik")]
        public string? Uzmanlik { get; set; }

        [Required]
        [ForeignKey("Salon")]
        [Column("kuafor_id")]
        public int KuaforId { get; set; }

        public Salon Salon { get; set; }

        public ICollection<CalisanHizmet> CalisanHizmetler { get; set; }
        public ICollection<CalisanUygunluk> CalisanUygunluklar { get; set; }
    }
}
