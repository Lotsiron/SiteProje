namespace WebApplication1.Models.ViewModels
{
    public class AdminPanelViewModel
    {
        public int ToplamSalon { get; set; }
        public int ToplamRandevu { get; set; }
        public int ToplamKullanici { get; set; }
        public List<Randevu> SonRandevular { get; set; }
    }
} 