using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface IAgiService
    {
        List<Agi> GetAll(string filter = null);
        Agi Get(string filter = null);
        void Add(Agi agi);
        void Delete(int id);
        void Update(Agi agi);
    }
}
