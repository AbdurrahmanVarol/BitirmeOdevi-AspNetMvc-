using BitirmeOdevi.Business.Abstract;
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
    public class SigortaManager : ISigortaService
    {
        private ISigortaDal _sigortaDal;

        public SigortaManager(ISigortaDal sigortaDal)
        {
            _sigortaDal = sigortaDal;
        }

        public void Add(Sigorta sigorta)
        {
            _sigortaDal.Add(sigorta);
        }

        public void Delete(int id)
        {
            try
            {
                _sigortaDal.Delete(id);
            }
            catch (DbUpdateException exception)
            {

            }
        }

        public Sigorta Get(string filter = null)
        {
            return _sigortaDal.Get(filter);
        }

        public List<Sigorta> GetAll(string filter = null)
        {
            return _sigortaDal.GetAll(filter);
        }



        public void Update(Sigorta sigorta)
        {
            _sigortaDal.Update(sigorta);
        }
    }
}
