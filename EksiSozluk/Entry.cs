using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk
{
    public class Entry
    {
        public int EntryID { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public int BaslkID { get; set; }
        public Baslik Baslik { get; set; }
        public int KullancID { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
