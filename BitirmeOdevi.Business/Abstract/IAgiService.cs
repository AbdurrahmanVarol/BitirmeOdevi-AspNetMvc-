using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface IAgiService
    {
        List<Agi> GetAll();
        Agi Get(int id);
        Agi GetByCondition(string condition);
        Agi GetByConditionAndChild(string condition,int numberOfChild);
        void Add(Agi agi);
        void Delete(Agi agi);
        void Update(Agi agi);
    }
}
