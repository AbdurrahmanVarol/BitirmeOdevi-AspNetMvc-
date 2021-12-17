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
    public class AgiManager : IAgiService
    {
        private IAgiDal _agiDal;

        public AgiManager(IAgiDal agiDal)
        {
            _agiDal = agiDal;
        }

        public void Add(Agi agi)
        {
            _agiDal.Add(agi);
        }

        public void Delete(int id)
        {
            try
            {
                _agiDal.Delete(id);
            }
            catch (DbUpdateException exception)
            {

            }
        }

        public Agi Get(string filter = null)
        {
            return _agiDal.Get(filter);
        }

        public List<Agi> GetAll(string filter = null)
        {
            return _agiDal.GetAll(filter);
        }



        public void Update(Agi agi)
        {
            _agiDal.Update(agi);
        }
    }
}
