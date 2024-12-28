using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("hizmetler")]
    public class Hizmet
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("ad")]
        public string Ad { get; set; }

        [Required]
        [Column("fiyat")]
        public decimal Fiyat { get; set; }

        [Required]
        [Column("sure")]
        public int Sure { get; set; }
    }

}
