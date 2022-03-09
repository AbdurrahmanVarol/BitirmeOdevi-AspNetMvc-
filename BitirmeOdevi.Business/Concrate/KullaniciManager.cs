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

        public void Delete(Kullanici kullanici)
        {
            try
            {
                _kullaniciDal.Delete(kullanici);
            }
            catch (Exception exception)
            {

            }
        }

        public Kullanici Get(int id)
        {
            return _kullaniciDal.Get(p => p.id == id);
        }
        public Kullanici GetByUserName(string userName)
        {
            return _kullaniciDal.Get(p => p.kullaniciAd == userName);
        }
        public Kullanici GetByUserNameAndPassword(string userName, string password)
        {
            return _kullaniciDal.Get(p => p.kullaniciAd == userName && p.sifre == password);
        }

        public List<Kullanici> GetAll()
        {
            return _kullaniciDal.GetAll();
        }



        public void Update(Kullanici kullanici)
        {
            _kullaniciDal.Update(kullanici);
        }
    }
}
