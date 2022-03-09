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
        List<VergiDilimi> GetAll(Expression<Func<VergiDilimi, bool>> filter = null);
        VergiDilimi Get(Expression<Func<VergiDilimi, bool>> filter);
        void Add(VergiDilimi vergi);
        void Delete(VergiDilimi vergi);
        void Update(VergiDilimi vergi);
    }
}
