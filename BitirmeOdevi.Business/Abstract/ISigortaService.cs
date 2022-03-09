using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface ISigortaService
    {
        List<Sigorta> GetAll();
        Sigorta Get(int id);
        void Add(Sigorta sigorta);
        void Delete(Sigorta sigorta);
        void Update(Sigorta sigorta);
    }
}
