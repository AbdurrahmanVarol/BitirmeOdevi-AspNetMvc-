using BitirmeOdevi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.Hesaplama
{
    public interface IHesapla
    {
        void NettenBrüte(HesaplaModel hesaplaModel, double netMaas, double gelirVergisi, double agi, double vergiMuhafiyeti, int emekliId);
        void BrüttenNete(HesaplaModel hesaplaModel, double brütMaas, double gelirVergisi, double agi, double vergiMuhafiyeti, int emekliId);
    }
}
