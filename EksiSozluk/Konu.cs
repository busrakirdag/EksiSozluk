using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk
{
    public class Konu
    {
        public int KonuID { get; set; }

        public string KonuAdi { get; set; }
        public List<Baslik> Baslik { get; set; } 
    }
}
