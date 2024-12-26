using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Hizmet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ad { get; set; }

        [Required]
        public decimal Fiyat { get; set; }

        [Required]
        public int Sure { get; set; } // Dakika türünden
    }

}
