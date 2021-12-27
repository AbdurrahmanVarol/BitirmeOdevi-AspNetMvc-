using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitirmeOdevi.Models
{
    public class HesaplaModel
    {
        public string ay { get; set; }
        public double brütMaas { get; set; }
        public double sgkIsciPayi { get; set; }
        public double sgkIssizlikIsciPayi { get; set; }        
        public double damgaVergisi { get; set; }
        public double gelirVergisi { get; set; }
        public double vergiDilim { get; set; }
        public double netTutar { get; set; }
        public double agi { get; set; }
        public double odenecekTutar { get; set; }
        public double sigortaVeİssizlikPayı { get; set; }      
    }
}