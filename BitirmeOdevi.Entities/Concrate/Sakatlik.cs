using BitirmeOdevi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Entities.Concrate
{
    public class Sakatlik:IEntity
    {
        public int sakatlikId { get; set; }
        public string sakatlikDerece { get; set; }
        public double indirim { get; set; }
        public int yil { get; set; }
        public double agiMiktari { get; set; }
    }
}
