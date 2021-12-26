using BitirmeOdevi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitirmeOdevi.Hesaplama
{
    public class Hesapla
    {
        double sgkIsciPayiOranı;
        double sgkIssizlikIsciPayiOranı;
        double sgkIsverenPayiOranı;
        double sgkIssizlikIsverenPayiOranı;
        double damgaVergisi;

        public HesaplaModel NettenBrüte(HesaplaModel hesaplaModel, double netMaas, double gelirVergisi, double agi, double vergiMuhafiyeti, int emekliId)
        {
            if (emekliId == 1)
            {
                sgkIsciPayiOranı = 0.14;
                sgkIssizlikIsciPayiOranı = 0.01;
                sgkIsverenPayiOranı = 0.155;
                sgkIssizlikIsverenPayiOranı = 0.02;
                damgaVergisi = 0.00759;
            }
            else
            {
                sgkIsciPayiOranı = 0.075;
                sgkIssizlikIsciPayiOranı = 0;
                sgkIsverenPayiOranı = 0.155;
                sgkIssizlikIsverenPayiOranı = 0.02;
                damgaVergisi = 0.00759;
            }
            double brütMaas;
            if (gelirVergisi == 0.15)
                brütMaas = netMaas * 1.3989;
            else if (gelirVergisi == 0.2)
            {
                brütMaas = netMaas * 1.3989;
                brütMaas += brütMaas * 0.06315;
            }
            else if (gelirVergisi == 0.27)
            {
                brütMaas = netMaas * 1.3989;
                brütMaas += brütMaas * 0.16635;
            }
            else if (gelirVergisi == 0.35)
            {
                brütMaas = netMaas * 1.3989;
                brütMaas += brütMaas * 0.3119;
            }
            else
            {
                brütMaas = netMaas * 1.3989;
                brütMaas += brütMaas * 0.42288;
            }
            double gelirVergisiMatrahi;
            double indirimSonrasiGelirVergisiMahrahi;
            double vergiKesintisi;
            double kesintiToplam;
            double aylikGelirVergisi;
            double netUcret;
            double odenecekTutar;
            double isverenMaaliyet;


            //sgk işçi payı %14
            double sgkIsciPayi = brütMaas * sgkIsciPayiOranı;
            //işsizlik işçi payı %1
            double sgkIssizlikIsciPayi = brütMaas * sgkIssizlikIsciPayiOranı;
            //gerlir vergisi matrahı = brüt maaş sgk işçi payı -işsizlik işçi payı
            gelirVergisiMatrahi = brütMaas - sgkIsciPayi - sgkIssizlikIsciPayi;

            indirimSonrasiGelirVergisiMahrahi = gelirVergisiMatrahi - vergiMuhafiyeti;
            //vergi kesintisi = gelir vergisi matrahı x gelir vergisi oranı + brüt maaş x damga vergisi
            aylikGelirVergisi = indirimSonrasiGelirVergisiMahrahi * gelirVergisi;

            vergiKesintisi = aylikGelirVergisi + brütMaas * damgaVergisi;

            kesintiToplam = sgkIsciPayi + sgkIssizlikIsciPayi + vergiKesintisi;

            netUcret = brütMaas - kesintiToplam;

            if (agi > aylikGelirVergisi)
                odenecekTutar = netUcret + aylikGelirVergisi;
            else
                odenecekTutar = netUcret + agi;

            // Eğer engelli birisini çalıştırıyorsa işveren maaliyetleri devlet tarafından karşılanır
            if (vergiMuhafiyeti != 0)
                isverenMaaliyet = 0;
            else
                isverenMaaliyet = brütMaas * sgkIsverenPayiOranı + brütMaas * sgkIssizlikIsverenPayiOranı;

            hesaplaModel.brütMaas = Math.Round(brütMaas, 2);
            hesaplaModel.sgkIsciPayi = Math.Round(sgkIsciPayi, 2);
            hesaplaModel.sgkIssizlikIsciPayi = Math.Round(sgkIssizlikIsciPayi, 2);
            hesaplaModel.damgaVergisi = Math.Round(gelirVergisiMatrahi * damgaVergisi, 2);
            hesaplaModel.gelirVergisi = Math.Round(gelirVergisiMatrahi * gelirVergisi, 2);
            hesaplaModel.vergiDilim = Convert.ToInt32(gelirVergisi * 100);
            hesaplaModel.netTutar = Math.Round(netUcret, 2);
            hesaplaModel.agi = Math.Round(agi, 2);
            hesaplaModel.odenecekTutar = Math.Round(odenecekTutar, 2);
            hesaplaModel.sigortaVeİssizlikPayı = Math.Round(isverenMaaliyet, 2);
            return hesaplaModel;

        }

        //Engelli için fark vargi muhafiyetini gelir vergisi mahrahından düşeceksin
        // Agi maksimum gelir vergisi kadar olabilir.

        public HesaplaModel BrüttenNete(HesaplaModel hesaplaModel, double brütMaas, double gelirVergisi, double agi, double vergiMuhafiyeti, int emekliId)
        {

            if (emekliId == 1)
            {
                sgkIsciPayiOranı = 0.14;
                sgkIssizlikIsciPayiOranı = 0.01;
                sgkIsverenPayiOranı = 0.155;
                sgkIssizlikIsverenPayiOranı = 0.02;
                damgaVergisi = 0.00759;
            }
            else
            {
                sgkIsciPayiOranı = 0.075;
                sgkIssizlikIsciPayiOranı = 0;
                sgkIsverenPayiOranı = 0.155;
                sgkIssizlikIsverenPayiOranı = 0.02;
                damgaVergisi = 0.00759;
            }
            double gelirVergisiMatrahi;
            double indirimSonrasiGelirVergisiMahrahi;
            double vergiKesintisi;
            double kesintiToplam;
            double aylikGelirVergisi;
            double netUcret;
            double odenecekTutar;
            double isverenMaaliyet;


            //sgk işçi payı %14
            double sgkIsciPayi = brütMaas * sgkIsciPayiOranı;
            //işsizlik işçi payı %1
            double sgkIssizlikIsciPayi = brütMaas * sgkIssizlikIsciPayiOranı;
            //gerlir vergisi matrahı = brüt maaş sgk işçi payı -işsizlik işçi payı
            gelirVergisiMatrahi = brütMaas - Math.Round(sgkIsciPayi, 2) - Math.Round(sgkIssizlikIsciPayi, 2);

            indirimSonrasiGelirVergisiMahrahi = Math.Round(gelirVergisiMatrahi, 2) - vergiMuhafiyeti;
            //vergi kesintisi = gelir vergisi matrahı x gelir vergisi oranı + brüt maaş x damga vergisi
            aylikGelirVergisi = indirimSonrasiGelirVergisiMahrahi * gelirVergisi;

            vergiKesintisi = Math.Round(aylikGelirVergisi, 2) + Math.Round(brütMaas * damgaVergisi, 2);

            kesintiToplam = sgkIsciPayi + sgkIssizlikIsciPayi + vergiKesintisi;

            netUcret = brütMaas - kesintiToplam;

            if (agi > aylikGelirVergisi)
                odenecekTutar = netUcret + aylikGelirVergisi;
            else
                odenecekTutar = netUcret + agi;

            // Eğer engelli birisini çalıştırıyorsa işveren maaliyetleri devlet tarafından karşılanır
            if (vergiMuhafiyeti != 0)
                isverenMaaliyet = 0;
            else
                isverenMaaliyet = brütMaas * sgkIsverenPayiOranı + brütMaas * sgkIssizlikIsverenPayiOranı;

            hesaplaModel.brütMaas = Math.Round(brütMaas, 2);
            hesaplaModel.sgkIsciPayi = Math.Round(sgkIsciPayi, 2);
            hesaplaModel.sgkIssizlikIsciPayi = Math.Round(sgkIssizlikIsciPayi, 2);
            hesaplaModel.damgaVergisi = Math.Round(indirimSonrasiGelirVergisiMahrahi * damgaVergisi, 2);
            hesaplaModel.gelirVergisi = Math.Round(indirimSonrasiGelirVergisiMahrahi * gelirVergisi, 2);
            hesaplaModel.vergiDilim = Convert.ToInt32(gelirVergisi * 100);
            hesaplaModel.netTutar = Math.Round(netUcret, 2);
            hesaplaModel.agi = Math.Round(agi, 2);
            hesaplaModel.odenecekTutar = Math.Round(odenecekTutar, 2);
            hesaplaModel.sigortaVeİssizlikPayı = Math.Round(isverenMaaliyet, 2);
            return hesaplaModel;
        }


        //public HesaplaModel BrüttenNete(double brütMaas, double gelirVergisi, double agi, double vergiMuhafiyeti)
        //{
        //    HesaplaModel hesaplaModel = new HesaplaModel();
        //    double gelirVergisiMatrahi;
        //    double vergiKesintisi;
        //    double kesintiToplam;
        //    double netUcret;
        //    double isverenMaaliyet;
        //    double sgkIsciPayi = brütMaas * sgkIsciPayiOranı;
        //    double sgkIssizlikIsciPayi = brütMaas * sgkIssizlikIsciPayiOranı;
        //    gelirVergisiMatrahi = brütMaas - sgkIsciPayi - sgkIssizlikIsciPayi;
        //    vergiKesintisi = gelirVergisiMatrahi * gelirVergisi + brütMaas * damgaVergisi;
        //    kesintiToplam = sgkIsciPayi + sgkIssizlikIsciPayi + vergiKesintisi;
        //    netUcret = brütMaas - kesintiToplam;
        //    isverenMaaliyet = brütMaas + brütMaas * sgkIsverenPayiOranı + brütMaas * sgkIssizlikIsverenPayiOranı;
        //    hesaplaModel.brütMaas = Math.Round(brütMaas, 2);
        //    hesaplaModel.sgkIsciPayi = Math.Round(sgkIsciPayi, 2);
        //    hesaplaModel.sgkIssizlikIsciPayi = Math.Round(sgkIssizlikIsciPayi, 2);
        //    hesaplaModel.damgaVergisi = Math.Round(gelirVergisiMatrahi * damgaVergisi, 2);
        //    hesaplaModel.gelirVergisi = Math.Round(gelirVergisiMatrahi * gelirVergisi, 2);
        //    hesaplaModel.vergiDilim = Convert.ToInt32(gelirVergisi * 100);
        //    hesaplaModel.netTutar = Math.Round(netUcret, 2);
        //    hesaplaModel.agi = Math.Round(agi, 2);
        //    hesaplaModel.odenecekTutar = Math.Round(netUcret + agi, 2);
        //    hesaplaModel.sigortaVeİssizlikPayı = Math.Round(isverenMaaliyet - brütMaas, 2);
        //    return hesaplaModel;
        ////}
        //public HesaplaModel NettenBrüte(double netMaas, double gelirVergisi, double agi, double vergiMuhafiyeti)
        //{
        //    HesaplaModel hesaplaModel = new HesaplaModel();
        //    double brütMaas = netMaas * 1.40;
        //    double gelirVergisiMatrahi;
        //    double indirimSonrasiGelirVergisiMahrahi;
        //    double vergiKesintisi;
        //    double kesintiToplam;
        //    double aylikGelirVergisi;
        //    double netUcret;
        //    double odenecekTutar;
        //    double isverenMaaliyet;


        //    //sgk işçi payı %14
        //    double sgkIsciPayi = brütMaas * sgkIsciPayiOranı;
        //    //işsizlik işçi payı %1
        //    double sgkIssizlikIsciPayi = brütMaas * sgkIssizlikIsciPayiOranı;
        //    //gerlir vergisi matrahı = brüt maaş sgk işçi payı -işsizlik işçi payı
        //    gelirVergisiMatrahi = brütMaas - sgkIsciPayi - sgkIssizlikIsciPayi;

        //    indirimSonrasiGelirVergisiMahrahi = gelirVergisiMatrahi - vergiMuhafiyeti;
        //    //vergi kesintisi = gelir vergisi matrahı x gelir vergisi oranı + brüt maaş x damga vergisi
        //    aylikGelirVergisi = indirimSonrasiGelirVergisiMahrahi * gelirVergisi;

        //    vergiKesintisi = aylikGelirVergisi + brütMaas * damgaVergisi;

        //    kesintiToplam = sgkIsciPayi + sgkIssizlikIsciPayi + vergiKesintisi;

        //    netUcret = brütMaas - kesintiToplam;

        //    if (agi > aylikGelirVergisi)
        //        odenecekTutar = netUcret + aylikGelirVergisi;
        //    else
        //        odenecekTutar = netUcret + agi;

        //    // Eğer engelli birisini çalıştırıyorsa işveren maaliyetleri devlet tarafından karşılanır
        //    if (vergiMuhafiyeti != 0)
        //        isverenMaaliyet = 0;
        //    else
        //        isverenMaaliyet = brütMaas + brütMaas * sgkIsverenPayiOranı + brütMaas * sgkIssizlikIsverenPayiOranı;

        //    hesaplaModel.brütMaas = Math.Round(brütMaas, 2);
        //    hesaplaModel.sgkIsciPayi = Math.Round(sgkIsciPayi, 2);
        //    hesaplaModel.sgkIssizlikIsciPayi = Math.Round(sgkIssizlikIsciPayi, 2);
        //    hesaplaModel.damgaVergisi = Math.Round(gelirVergisiMatrahi * damgaVergisi, 2);
        //    hesaplaModel.gelirVergisi = Math.Round(gelirVergisiMatrahi * gelirVergisi, 2);
        //    hesaplaModel.vergiDilim = Convert.ToInt32(gelirVergisi * 100);
        //    hesaplaModel.netTutar = Math.Round(netUcret, 2);
        //    hesaplaModel.agi = Math.Round(agi, 2);
        //    hesaplaModel.odenecekTutar = Math.Round(odenecekTutar, 2);
        //    hesaplaModel.sigortaVeİssizlikPayı = Math.Round(isverenMaaliyet - brütMaas, 2);
        //    return hesaplaModel;

        //}

    }
}