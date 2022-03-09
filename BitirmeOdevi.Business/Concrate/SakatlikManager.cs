using BitirmeOdevi.Business.Abstract;
using BitirmeOdevi.DataAccess.Abstract;
using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Concrate
{
    public class SakatlikManager : ISakatlikService
    {
        private ISakatlikDal _sakatlikDal;

        public SakatlikManager(ISakatlikDal sakatlikDal)
        {
            _sakatlikDal = sakatlikDal;
        }

        public void Add(Sakatlik sakatlik)
        {
            _sakatlikDal.Add(sakatlik);
        }

        public void Delete(Sakatlik sakatlik)
        {
            try
            {
                _sakatlikDal.Delete(sakatlik);
            }
            catch (Exception exception)
            {

            }
        }

        public Sakatlik Get(Expression<Func<Sakatlik, bool>> filter)
        {
            return _sakatlikDal.Get(filter);
        }

        public List<Sakatlik> GetAll(Expression<Func<Sakatlik, bool>> filter = null)
        {
            return _sakatlikDal.GetAll(filter);
        }



        public void Update(Sakatlik sakatlik)
        {
            _sakatlikDal.Update(sakatlik);
        }
    }
}
