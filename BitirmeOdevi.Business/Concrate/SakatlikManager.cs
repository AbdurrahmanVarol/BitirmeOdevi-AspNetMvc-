using BitirmeOdevi.Business.Abstract;
using BitirmeOdevi.DataAccess.Abstract;
using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
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

        public void Delete(int id)
        {
            try
            {
                _sakatlikDal.Delete(id);
            }
            catch (DbUpdateException exception)
            {

            }
        }

        public Sakatlik Get(string filter = null)
        {
            return _sakatlikDal.Get(filter);
        }

        public List<Sakatlik> GetAll(string filter = null)
        {
            return _sakatlikDal.GetAll(filter);
        }



        public void Update(Sakatlik sakatlik)
        {
            _sakatlikDal.Update(sakatlik);
        }
    }
}
