using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface IKullaniciService
    {
        List<Kullanici> GetAll();
        Kullanici Get(int id);
        Kullanici GetByUserName(string userName);
        Kullanici GetByUserNameAndPassword(string userName,string password);
        void Add(Kullanici kullanici);
        void Delete(Kullanici kullanici);
        void Update(Kullanici kullanici);        
    }
}
