using BitirmeOdevi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Entities.Concrate
{
    public class Oranlar:IEntity
    {
        public int oranId { get; set; }
        public int yilId { get; set; }
        public double sgkIsciPayiOranı { get; set; }
        public double sgkIssizlikIsciPayiOranı { get; set; }
        public double sgkIsverenPayiOranı { get; set; }
        public double sgkIssizlikIsverenPayiOranı { get; set; }
        public double gelirVergisi { get; set; }
        public double damgaVergisi { get; set; }
    }
}
