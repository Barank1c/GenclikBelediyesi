namespace GenclikBelediyesi.Models.Database
{
    public partial class TblHaberler
    {
        public int HaberId { get; set; }
        public string Foto1 { get; set; }
        public string Foto2 { get; set; }
        public string Foto3 { get; set; }
        public string Foto4 { get; set; }
        public string Foto5 { get; set; }
        public string Foto6 { get; set; }
        public string Foto7 { get; set; }
        public string Foto8 { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Icerik1 { get; set; }
        public string Icerik2 { get; set; }
        public bool Aktif { get; set; }
        public DateTime BasTarih { get; set; }
        public DateTime BitTarih { get; set; }
        public DateTime EklemeTarih { get; set; }
    }
}
