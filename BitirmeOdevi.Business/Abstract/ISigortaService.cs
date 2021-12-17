using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface ISigortaService
    {
        List<Sigorta> GetAll(string filter = null);
        Sigorta Get(string filter = null);
        void Add(Sigorta sigorta);
        void Delete(int id);
        void Update(Sigorta sigorta);
    }
}
