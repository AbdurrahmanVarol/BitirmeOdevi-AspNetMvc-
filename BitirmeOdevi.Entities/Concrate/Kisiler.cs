using BitirmeOdevi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Entities.Concrate
{
    public class Kisiler:IEntity
    {
        public int kisiId { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public double maas { get; set; }
        public int kullaniciId { get; set; }
        public int agiId { get; set; }
        public int sakatlikId { get; set; }
        public int sigortaId { get; set; }
    }
}
