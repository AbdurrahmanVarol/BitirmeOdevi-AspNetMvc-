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
        List<Sakatlik> GetAll(Expression<Func<Sakatlik, bool>> filter = null);
        Sakatlik Get(Expression<Func<Sakatlik, bool>> filter);
        void Add(Sakatlik sakatlik);
        void Delete(Sakatlik sakatlik);
        void Update(Sakatlik sakatlik);
    }
}
