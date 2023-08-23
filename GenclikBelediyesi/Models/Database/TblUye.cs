using Microsoft.AspNetCore.Identity;

namespace GenclikBelediyesi.Models.Database
{
    public partial class TblUye: IdentityUser
    {
        public DateTime DogumTarih { get; set; }
    }
}
