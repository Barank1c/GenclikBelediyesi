using GenclikBelediyesi.Models.Database;
using X.PagedList;

namespace GenclikBelediyesi.Models
{
	public class HaberlerModel
	{
		public int month;
		public int year;
		public PagedList<TblHaberler> list;
		public string search;
	}
}
