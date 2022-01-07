using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk
{
    public class Baslik
    {
        public int BaslikID { get; set; }
        public string BaslikAdi { get; set; }
        public int KonID { get; set; }
        public Konu Konu { get; set; }
        public List<Entry> Entry { get; set; }
    }
}
