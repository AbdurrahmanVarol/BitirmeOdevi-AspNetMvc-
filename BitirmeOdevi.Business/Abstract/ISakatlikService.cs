using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface ISakatlikService
    {
        List<Sakatlik> GetAll(string filter = null);
        Sakatlik Get(string filter = null);
        void Add(Sakatlik sakatlik);
        void Delete(int id);
        void Update(Sakatlik sakatlik);
    }
}
