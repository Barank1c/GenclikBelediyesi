using GenclikBelediyesi.Models.Database;

public class HomeModel
{
    public HomeModel(GenclikBelediyesiContext dbb)
    {
        haberlerList = dbb.TblHaberler.Where(d => d.Aktif).ToList();
        etkinlikList = dbb.TblEtkinlikler.Where(d => d.Aktif).ToList();
    }
    public List<TblHaberler> haberlerList;
    public List<TblEtkinlikler> etkinlikList;
}