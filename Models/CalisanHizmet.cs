using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Table("calisan_hizmetler")]
    public class CalisanHizmet
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Calisan")]
        [Column("calisan_id")]
        public int CalisanId { get; set; }

        [Required]
        [ForeignKey("Hizmet")]
        [Column("hizmet_id")]
        public int HizmetId { get; set; }

        public Calisan Calisan { get; set; }
        public Hizmet Hizmet { get; set; }
    }

}
