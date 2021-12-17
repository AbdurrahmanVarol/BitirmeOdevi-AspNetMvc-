﻿using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Business.Abstract
{
    public interface IKisilerService
    {
        List<Kisiler> GetAll(string filter = null);
        Kisiler Get(string filter = null);
        void Add(Kisiler kisi);
        void Delete(int id);
        void Update(Kisiler kisi);
    }
}
