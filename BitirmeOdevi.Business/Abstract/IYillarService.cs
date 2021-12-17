using BitirmeOdevi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface IYillarService
    {
        
        Yillar Get(int Id);
        
    }
}
