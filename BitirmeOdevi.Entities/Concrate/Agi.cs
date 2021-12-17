using BitirmeOdevi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Entities.Concrate
{
    public class Agi:IEntity
    {
        public int agiId{ get; set; }
        public string medeniDurum { get; set; }
        public int cocukSayisi { get; set; }
        public double agiMiktari { get; set; }
        public int yil{ get; set; }
    }
}
