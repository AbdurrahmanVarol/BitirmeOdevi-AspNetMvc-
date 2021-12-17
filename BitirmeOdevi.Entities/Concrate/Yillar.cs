using BitirmeOdevi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Entities
{
   
    public class Yillar: IEntity
    {
        
        public int id { get; set; }
        public int yil { get; set; }
    }
}
