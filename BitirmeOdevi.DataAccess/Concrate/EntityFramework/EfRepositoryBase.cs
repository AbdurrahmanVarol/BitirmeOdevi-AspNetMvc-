using BitirmeOdevi.Entities.Abstract;
using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.DataAccess.Concrate.EntityFramework
{
    public class EfRepositoryBase<T> where T: class,IEntity,new()
    {
        public void Add(T entity)
        {
          
        }
        public void Delete(int id)
        {
          
        }

        public T Get(string filter = null)
        {
            return null;
        }

        public List<T> GetAll(string filter = null)
        {
            return null;
        }

        public void Update(T entity)
        {
            
        }
    }
}
