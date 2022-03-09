using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface IKisilerService
    {
        List<Kisiler> GetAll();
        List<Kisiler> GetAllByUserId(int userId);
        Kisiler Get(int id);
        void Add(Kisiler kisi);
        void Delete(Kisiler kisi);
        void Update(Kisiler kisi);
    }
}
