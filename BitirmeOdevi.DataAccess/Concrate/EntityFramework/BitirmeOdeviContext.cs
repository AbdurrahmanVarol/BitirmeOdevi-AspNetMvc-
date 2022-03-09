using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.DataAccess.Concrate.EntityFramework
{
    public class BitirmeOdeviContext:DbContext
    {
        public DbSet<Agi> Agis { get; set; }
        public DbSet<Kisiler> Kisilers { get; set; }
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Sakatlik> Sakatliks { get; set; }
        public DbSet<Sigorta> Sigortas { get; set; }
        public DbSet<VergiDilimi> VergiDilimis { get; set; }
    }
}
