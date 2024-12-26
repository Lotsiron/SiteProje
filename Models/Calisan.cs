using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Calisan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ad { get; set; }

        public string Uzmanlik { get; set; }

        [Required]
        [ForeignKey("Kuafor")]
        public int KuaforId { get; set; }

        public Salon Salon { get; set; }

        public ICollection<CalisanHizmet> CalisanHizmetler { get; set; }
        public ICollection<CalisanUygunluk> CalisanUygunluklar { get; set; }
    }
}
