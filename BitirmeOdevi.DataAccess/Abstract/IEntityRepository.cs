using BitirmeOdevi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(string filter = null);
        T Get(string filter = null);
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
