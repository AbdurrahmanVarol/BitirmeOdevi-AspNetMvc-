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
            catch (Exception)
            {

            }
        }

        public VergiDilimi Get(int id)
        {
            return _vergiDilimiDal.Get(p=>p.id==id);
        }
        public VergiDilimi GetByTotalSalary(double totalSalary)
        {
            return _vergiDilimiDal.Get(p => p.minMaas<= totalSalary && p.maxMaas>= totalSalary);
        }


        public List<VergiDilimi> GetAll()
        {
            return _vergiDilimiDal.GetAll();
        }



        public void Update(VergiDilimi vergi)
        {
            _vergiDilimiDal.Update(vergi);
        }
    }
}
