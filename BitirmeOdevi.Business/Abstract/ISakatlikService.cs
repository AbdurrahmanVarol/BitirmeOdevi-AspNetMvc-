using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface ISakatlikService
    {
        List<Sakatlik> GetAll();
        Sakatlik Get(int id);
        void Add(Sakatlik sakatlik);
        void Delete(Sakatlik sakatlik);
        void Update(Sakatlik sakatlik);
    }
}
