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
    public class KisilerManager
    {
        private IKisilerDal _kisilerDal;

        public KisilerManager(IKisilerDal kisilerDal)
        {
            _kisilerDal = kisilerDal;
        }       

        public void Add(Kisiler kisi)
        {
            _kisilerDal.Add(kisi);
        }

        public void Delete(int id)
        {
            try
            {
                _kisilerDal.Delete(id);
            }
            catch (DbUpdateException exception)
            {

            }
        }

        public Kisiler Get(string filter = null)
        {
            return _kisilerDal.Get(filter);
        }

        public List<Kisiler> GetAll(string filter = null)
        {
            return _kisilerDal.GetAll(filter);
        }



        public void Update(Kisiler kisi)
        {
            _kisilerDal.Update(kisi);
        }
    }
}
