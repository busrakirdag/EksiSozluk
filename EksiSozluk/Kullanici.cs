using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }

        public string KullaniciAdi { get; set; }

        public List<Entry> Entry { get; set; }
    }
}
