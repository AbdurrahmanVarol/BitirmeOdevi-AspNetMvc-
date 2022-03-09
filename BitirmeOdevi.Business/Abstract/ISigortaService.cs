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
        List<Sigorta> GetAll(Expression<Func<Sigorta, bool>> filter = null);
        Sigorta Get(Expression<Func<Sigorta, bool>> filter);
        void Add(Sigorta sigorta);
        void Delete(Sigorta sigorta);
        void Update(Sigorta sigorta);
    }
}
