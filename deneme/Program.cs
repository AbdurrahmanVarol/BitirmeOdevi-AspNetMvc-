using BitirmeOdevi.Business.Concrate;
using BitirmeOdevi.DataAccess.Abstract;
using BitirmeOdevi.DataAccess.Concrate;
using BitirmeOdevi.Entities;
using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme
{
    class Program
    {
        
        static void Main(string[] args)
        {
            KisilerManager kisilerManager = new KisilerManager(new KisilerDal());
            Kisiler kisiler = new Kisiler
            {
                ad = "Ayşe",
                soyad="Yılmaz",
                maas = 6500,
                medeniDurum = "bekar",
                cocukSayisi = 0,
                sakatlikId = 1
            };
            Kisiler kisiler1 = new Kisiler
            {
                ad = "Ali",
                soyad = "Al",
                maas = 6500,
                medeniDurum = "bekar",
                cocukSayisi = 0,
                sakatlikId = 1
            };
            Kisiler kisiler2 = new Kisiler
            {
                ad = "Kazım",
                soyad = "Kaz",
                maas = 6500,
                medeniDurum = "bekar",
                cocukSayisi = 0,
                sakatlikId = 1
            };

            kisilerManager.Add(kisiler);
            kisilerManager.Add(kisiler2);
            kisilerManager.Add(kisiler1);
            Console.WriteLine("Eklendi.");
            Console.ReadLine();
        }
    }
}
