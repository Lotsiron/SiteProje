using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("kullanicilar")]
    public class Kullanici
    {
        [Key]
        [Column("id")]
        // id otomatik artış
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Column("sifre")]
        [MaxLength(100)]
        public string Sifre { get; set; }

        [Required]
        [Column("ad")]
        [MaxLength(50)]
        public string Ad { get; set; }

        [Required]
        [Column("soyad")]
        [MaxLength(50)]
        public string Soyad { get; set; }

        [Column("telefon")]
        [MaxLength(15)]
        public string Telefon { get; set; }

        [Required]
        [Column("rol_id")]
        public int RolId { get; set; }

        public virtual Rol? Rol { get; set; }

        [Column("olusturma_tarihi")]
        public DateTime OlusmaTarihi { get; set; } = DateTime.Now;
    }
} 