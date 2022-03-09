using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface IVergiDİlimiService
    {
        List<VergiDilimi> GetAll();
        VergiDilimi Get(int id);
        VergiDilimi GetByTotalSalary(double totalSalary);
        void Add(VergiDilimi vergi);
        void Delete(VergiDilimi vergi);
        void Update(VergiDilimi vergi);
    }
}
