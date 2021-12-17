using BitirmeOdevi.Business.Abstract;
using BitirmeOdevi.DataAccess.Abstract;
using BitirmeOdevi.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Concrate
{
    public class KullaniciManager : IKullaniciService
    {
        private IKullaniciDal _kullaniciDal;
        public KullaniciManager(IKullaniciDal kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }

        public void Add(Kullanici kullanici)
        {
            _kullaniciDal.Add(kullanici);
        }

        public void Delete(int id)
        {
            try
            {
                _kullaniciDal.Delete(id);
            }
            catch(DbUpdateException exception)
            {
                
            }
        }

        public Kullanici Get(string filter=null)
        {
            return _kullaniciDal.Get(filter);
        }

        public List<Kullanici> GetAll(string filter=null)
        {
            return _kullaniciDal.GetAll(filter);
        }


        
        public void Update(Kullanici kullanici)
        {
            _kullaniciDal.Update(kullanici);
        }
    }
}
