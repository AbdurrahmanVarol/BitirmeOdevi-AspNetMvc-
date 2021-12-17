using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitirmeOdevi.Models
{
    public class userModel
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string kullaniciAd { get; set; }
        public string sifre { get; set; }
        public string sifreTekrar { get; set; }
        public string email { get; set; }
        public int yetkiId { get; set; }
    }
}