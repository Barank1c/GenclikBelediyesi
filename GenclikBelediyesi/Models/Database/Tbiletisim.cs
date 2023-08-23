using System;
using System.Collections.Generic;

namespace GenclikBelediyesi.Models.Database
{
    public partial class Tbiletisim
    {
        public int TbiletisimId { get; set; }
        public string iletisimAdiniz { get; set; }
        public string iletisimSoyadiniz { get; set; }
        public string iletisimMailiniz { get; set; }
        public string iletisimMesaj { get; set; }

    }
}
