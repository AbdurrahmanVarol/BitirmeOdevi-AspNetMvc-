using BitirmeOdevi.DataAccess.Abstract;
using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BitirmeOdevi.DataAccess.Concrate.EntityFramework
{
    public class EfKullaniciDal : EfRepositoryBase<Kullanici>, IKullaniciDal
    {
       
    }
}
