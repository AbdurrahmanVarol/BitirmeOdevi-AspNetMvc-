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

        public void Delete(VergiDilimi vergi)
        {
            try
            {
                _vergiDilimiDal.Delete(vergi);
            }
            catch (Exception exception)
            {

            }
        }

        public VergiDilimi Get(Expression<Func<VergiDilimi, bool>> filter)
        {
            return _vergiDilimiDal.Get(filter);
        }

        public List<VergiDilimi> GetAll(Expression<Func<VergiDilimi, bool>> filter = null)
        {
            return _vergiDilimiDal.GetAll(filter);
        }



        public void Update(VergiDilimi vergi)
        {
            _vergiDilimiDal.Update(vergi);
        }
    }
}
