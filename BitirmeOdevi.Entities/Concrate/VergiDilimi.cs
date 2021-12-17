using BitirmeOdevi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Entities.Concrate
{
    public class VergiDilimi:IEntity
    {
        public int id { get; set; }
        public double minMaas{ get; set; }
        public double maxMaas { get; set; }
        public double vergiDilimi { get; set; }
    }
}
