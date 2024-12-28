using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("roller")]
    public class Rol
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("ad")]
        [MaxLength(50)]
        public string Ad { get; set; }

        public ICollection<Kullanici> Kullanicilar { get; set; }
    }
} 