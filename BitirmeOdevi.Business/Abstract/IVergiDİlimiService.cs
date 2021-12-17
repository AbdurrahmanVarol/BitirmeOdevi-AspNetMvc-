using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface IVergiDİlimiService
    {
        List<VergiDilimi> GetAll(string filter = null);
        VergiDilimi Get(string filter = null);
        void Add(VergiDilimi vergi);
        void Delete(int id);
        void Update(VergiDilimi vergi);
    }
}
