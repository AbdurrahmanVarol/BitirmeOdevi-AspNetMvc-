using BitirmeOdevi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface IKullaniciService
    {
        List<Kullanici> GetAll(string filter = null);
        Kullanici Get(string filter = null);
        void Add(Kullanici kullanici);
        void Delete(int id);
        void Update(Kullanici kullanici);        
    }
}
