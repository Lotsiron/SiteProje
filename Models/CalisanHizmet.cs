using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CalisanHizmet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Calisan")]
        public int CalisanId { get; set; }

        [Required]
        [ForeignKey("Hizmet")]
        public int HizmetId { get; set; }

        public Calisan Calisan { get; set; }
        public Hizmet Hizmet { get; set; }
    }

}
