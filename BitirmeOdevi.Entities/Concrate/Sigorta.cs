using BitirmeOdevi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Entities.Concrate
{
    public class Sigorta:IEntity
    {
        public int sigortaId { get; set; }
        public string sigortaDurun { get; set; }
        public double miktar { get; set; }
        public double yil { get; set; }
    }
}
