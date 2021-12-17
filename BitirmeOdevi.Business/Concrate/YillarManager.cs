using BitirmeOdevi.Business.Abstract;
using BitirmeOdevi.DataAccess.Abstract;
using BitirmeOdevi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Concrate
{
    public class YillarManager : IYillarService
    {
        IYillarDal _yillarDal;
        public YillarManager(IYillarDal yillarDal)
        {
            _yillarDal = yillarDal;
        }
       
        public Yillar Get(int Id)
        {
            return _yillarDal.Get();
        }

       
    }
}
