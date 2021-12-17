using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitirmeOdevi.Models
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public string loginErronMeggase {get;set;}

    }
}