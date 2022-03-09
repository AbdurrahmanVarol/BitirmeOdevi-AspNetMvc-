﻿using BitirmeOdevi.Business.Abstract;
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
    public class SigortaManager : ISigortaService
    {
        private ISigortaDal _sigortaDal;

        public SigortaManager(ISigortaDal sigortaDal)
        {
            _sigortaDal = sigortaDal;
        }

        public void Add(Sigorta sigorta)
        {
            _sigortaDal.Add(sigorta);
        }

        public void Delete(Sigorta sigorta)
        {
            try
            {
                _sigortaDal.Delete(sigorta);
            }
            catch (Exception exception)
            {

            }
        }

        public Sigorta Get(Expression<Func<Sigorta, bool>> filter)
        {
            return _sigortaDal.Get(filter);
        }

        public List<Sigorta> GetAll(Expression<Func<Sigorta, bool>> filter = null)
        {
            return _sigortaDal.GetAll(filter);
        }



        public void Update(Sigorta sigorta)
        {
            _sigortaDal.Update(sigorta);
        }
    }
}
