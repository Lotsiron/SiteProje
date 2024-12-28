using WebApplication1.Models;

public class RandevuOlusturViewModel
{
    public Calisan Calisan { get; set; }
    public Hizmet Hizmet { get; set; }
    public List<Randevu> MevcutRandevular { get; set; }
}

public class RandevuCreateModel
{
    public int kuafor_id { get; set; }
    public int calisan_id { get; set; }
    public int hizmet_id { get; set; }
    public string musteri_adi { get; set; }
    public string telefon { get; set; }
    public DateTime tarih { get; set; }
    public TimeSpan baslangic_saati { get; set; }
}