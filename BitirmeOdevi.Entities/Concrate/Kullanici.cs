using BitirmeOdevi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Entities.Concrate
{
    public class Kullanici:IEntity
    {
        public int id  { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string kullaniciAd { get; set; }
        public string sifre { get; set; }
        public string email { get; set; }
        public int yetkiId { get; set; }
    }
}
