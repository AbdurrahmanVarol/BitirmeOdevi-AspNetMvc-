using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitirmeOdevi.Models
{
    public class Kisi
    {
        public int id { get; set; }
        public int kullaniciId { get; set; }
        public string fName{ get; set; }
        public string lName { get; set; }
        public double salary { get; set; }

    }
}