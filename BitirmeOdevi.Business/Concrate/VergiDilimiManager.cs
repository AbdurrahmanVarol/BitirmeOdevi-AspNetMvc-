using BitirmeOdevi.Business.Abstract;
using BitirmeOdevi.DataAccess.Abstract;
using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Concrate
{
    public class VergiDilimiManager:IVergiDİlimiService
    {
        private IVergiDilimiDal _vergiDilimiDal;

        public VergiDilimiManager(IVergiDilimiDal vergiDilimiDal)
        {
            _vergiDilimiDal = vergiDilimiDal;
        }

        public void Add(VergiDilimi vergi)
        {
            _vergiDilimiDal.Add(vergi);
        }

        public void Delete(int id)
        {
            try
            {
                _vergiDilimiDal.Delete(id);
            }
            catch (Exception exception)
            {

            }
        }

        public VergiDilimi Get(string filter = null)
        {
            return _vergiDilimiDal.Get(filter);
        }

        public List<VergiDilimi> GetAll(string filter = null)
        {
            return _vergiDilimiDal.GetAll(filter);
        }



        public void Update(VergiDilimi vergi)
        {
            _vergiDilimiDal.Update(vergi);
        }
    }
}
