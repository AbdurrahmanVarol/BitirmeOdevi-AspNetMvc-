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

        public void Delete(Agi agi)
        {
            try
            {
                _agiDal.Delete(agi);
            }
            catch (Exception exception)
            {
                Console.Write(exception);
            }
        }

        public Agi Get(int id)
        {
            return _agiDal.Get(p=>p.agiId==id);
        }
        public Agi GetByCondition(string condition)
        {
            return _agiDal.Get(p => p.medeniDurum==condition);
        }
        public Agi GetByConditionAndChild(string condition,int numberOfChild)
        {
            return _agiDal.Get(p => p.medeniDurum==condition && p.cocukSayisi==numberOfChild);
        }

        public List<Agi> GetAll()
        {
            return _agiDal.GetAll();
        }



        public void Update(Agi agi)
        {
            _agiDal.Update(agi);
        }
    }
}
