using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitirmeOdevi.Models
{
    public class kisiModel
    {
        public int id { get; set; }
        public string ad{ get; set; }
        public string soyad { get; set; }
        public double maas { get; set; }
        public int kullaniciId { get; set; }
        public string medeniDurum { get; set; }
        public int cocukSayisi { get; set; }
        public int sakatlikId { get; set; }
        public int sigortaId { get; set; }
    }
}