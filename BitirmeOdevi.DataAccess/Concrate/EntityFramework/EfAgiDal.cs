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
using BitirmeOdevi.DataAccess.Concrate.EntityFramework;

namespace BitirmeOdevi.DataAccess.Concrate
{
    public class EfAgiDal: EfRepositoryBase<Agi>,IAgiDal
    {
        
    }
}
