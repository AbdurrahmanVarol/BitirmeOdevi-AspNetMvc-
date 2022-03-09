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
    public class KisilerManager : IKisilerService
    {
        private IKisilerDal _kisilerDal;

        public KisilerManager(IKisilerDal kisilerDal)
        {
            _kisilerDal = kisilerDal;
        }       

        public void Add(Kisiler kisi)
        {
            _kisilerDal.Add(kisi);
        }

        public void Delete(Kisiler kisi)
        {
            try
            {
                _kisilerDal.Delete(kisi);
            }
            catch (Exception)
            {

            }
        }

        public Kisiler Get(int kisiId)
        {
            return _kisilerDal.Get(p=>p.kisiId==kisiId);
        }

        public List<Kisiler> GetAll()
        {
            return _kisilerDal.GetAll();
        }
        public List<Kisiler> GetAllByUserId(int userId)
        {
            return _kisilerDal.GetAll(p=>p.kullaniciId==userId);
        }



        public void Update(Kisiler kisi)
        {
            _kisilerDal.Update(kisi);
        }
    }
}
