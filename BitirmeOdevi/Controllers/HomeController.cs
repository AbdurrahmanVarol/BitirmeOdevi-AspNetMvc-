using BitirmeOdevi.Business.Concrate;
using BitirmeOdevi.DataAccess.Concrate;
using BitirmeOdevi.Entities;
using BitirmeOdevi.Entities.Concrate;
using BitirmeOdevi.Hesaplama;
using BitirmeOdevi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeOdevi.Controllers
{
    public class HomeController : Controller
    {
        KullaniciManager _kullaniciManager = new KullaniciManager(new KullaniciDal());
        KisilerManager _kisilerManager = new KisilerManager(new KisilerDal());
        VergiDilimiManager _vergiDilimiManager = new VergiDilimiManager(new VergiDilimiDal());
        AgiManager _agiManager = new AgiManager(new AgiDal());
        SigortaManager _sigortaManager = new SigortaManager(new SigortaDal());
        SakatlikManager _sakatlikManager = new SakatlikManager(new SakatlikDal());
        List<string> _aylar = new List<string>();

        public void ayEkle()
        {
            _aylar.Add("ocak");
            _aylar.Add("subat");
            _aylar.Add("mart");
            _aylar.Add("nisan");
            _aylar.Add("mayıs");
            _aylar.Add("haziran");
            _aylar.Add("temmuz");
            _aylar.Add("ağustos");
            _aylar.Add("eylül");
            _aylar.Add("ekim");
            _aylar.Add("kasım");
            _aylar.Add("aralık");
            
        }
       
        // GET: Home3

        [HttpGet]
        public ActionResult Index()
        {
            if (Request.Cookies.AllKeys.Contains("Login"))
            {
                List<Kisiler> kisiDatabase = new List<Kisiler>();
                List<kisiModel> kisiModels = new List<kisiModel>();
                ViewBag.id = Request.Cookies["Login"].Value;
                kisiDatabase = _kisilerManager.GetAll("kullaniciId="+ Request.Cookies["Login"].Value.ToString());
                
                foreach (var val in kisiDatabase)
                {
                    kisiModel kisiModel = new kisiModel()
                    {
                        id = val.kisiId,
                        ad = val.ad,
                        soyad = val.soyad,
                        maas = val.maas,
                        kullaniciId=val.kullaniciId
                    };
                    
                    kisiModels.Add(kisiModel);
                }
                return View(kisiModels);
            }
            else
                return RedirectToAction("Login", "Security");      
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            //Random random = new Random();
            //List<Kisi> kisiler = new List<Kisi>();
            //for (int i = 1; i <= 5; i++)
            //{
            //    Kisi kisi = new Kisi()
            //    {
            //        id = i,
            //        fName = "first name",
            //        lName = "last name",
            //        salary = random.Next(4000, 6000)

            //    };
            //    kisiler.Add(kisi);
            //}
            return View();
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View("kisiEkle");
        }
        [HttpPost]
        public ActionResult Kaydet(kisiModel kisiModel)
        {
            Kisiler kisi = new Kisiler()
            {
                kisiId = kisiModel.id,
                ad = kisiModel.ad,
                soyad = kisiModel.soyad,
                maas = kisiModel.maas,
                kullaniciId = Convert.ToInt32(Request.Cookies["Login"].Value),
                sakatlikId = kisiModel.sakatlikId,
                sigortaId = kisiModel.sigortaId
            };
            if (kisiModel.medeniDurum == "Faydalanmayacak")
                kisi.agiId = 1;
            else if (kisiModel.medeniDurum == "Bekar")
                kisi.agiId = 2;
            else
                kisi.agiId = _agiManager.Get("medeniDurum='" + kisiModel.medeniDurum + "' and cocukSayisi=" +kisiModel.cocukSayisi.ToString()).agiId;

            if (kisiModel.id != 0)

                _kisilerManager.Update(kisi);
            else
                _kisilerManager.Add(kisi);
            
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Düzenle(int id)
        {
            var kisi = _kisilerManager.Get("kisiId=" + id.ToString());
            var agi = _agiManager.Get("agiId=" + kisi.agiId.ToString());

            kisiModel kisiModel = new kisiModel()
            {
                id = id,
                ad = kisi.ad,
                soyad = kisi.soyad,
                maas = kisi.maas,
                kullaniciId = kisi.kullaniciId,
                medeniDurum = agi.medeniDurum,
                cocukSayisi = agi.cocukSayisi,
                sakatlikId = kisi.sakatlikId,
                sigortaId = kisi.sigortaId
            };
            return View("kisiGuncelle", kisiModel);
        }

        [HttpGet]
        public ActionResult Hesapla(int id)
        {
            double toplamMaas=0;
            double vergi;
            double agi;
            double vergiMuhafiyeti;
            Kisiler kisi = new Kisiler();
            Hesapla hesapla = new Hesapla();
            List<double> data = new List<double>();
            kisi = _kisilerManager.Get("kisiId=" + id.ToString());
            HesaplaModel hesaplaModel = new HesaplaModel();
            List<HesaplaModel> hesaplaModels = new List<HesaplaModel>();
            ayEkle();

            foreach (var ay in _aylar)
            {
                toplamMaas += kisi.maas;
                vergi = _vergiDilimiManager.Get("minMaas <=" + toplamMaas.ToString() + " and maxMaas > " + toplamMaas.ToString()).vergiDilimi;
                agi = _agiManager.Get("agiId=" + kisi.agiId.ToString()).agiMiktari;
                vergiMuhafiyeti = _sakatlikManager.Get("sakatlikId=" + kisi.sakatlikId.ToString()).indirim;
                hesaplaModel = hesapla.BrüttenNete(kisi.maas, vergi, agi, vergiMuhafiyeti);
                hesaplaModel.ay = ay;
                hesaplaModels.Add(hesaplaModel);
            }
            //foreach(var ay in _aylar)
            //{
            //    toplamMaas += kisi.maas;
            //    vergi = _vergiDilimiManager.Get("minMaas <=" + toplamMaas.ToString() + " and maxMaas > " + toplamMaas.ToString()).vergiDilimi;

            //    //hesaplaModel = hesapla.BrüttenNete(kisi.maas, vergi, vergiMuhafiyeti);
            //    hesaplaModel.ay = ay;
            //    hesaplaModels.Add(hesaplaModel);
            //}   
            return View("Hesapla", hesaplaModels);
            //var kisi = _kullaniciManager.GetById(id);
            //if (kisi != null)
            //    return View("Hesapla", kisi);
            //else
            //    return HttpNotFound();
        }
        [HttpGet]
        public ActionResult BRÜT(int id)
        {
            double toplamMaas = 0;
            double vergi;
            double agi;
            double vergiMuhafiyeti;
            Kisiler kisi = new Kisiler();
            Hesapla hesapla = new Hesapla();
            List<double> data = new List<double>();
            kisi = _kisilerManager.Get("kisiId=" + id.ToString());
            HesaplaModel hesaplaModel = new HesaplaModel();
            List<HesaplaModel> hesaplaModels = new List<HesaplaModel>();
            ayEkle();

            foreach (var ay in _aylar)
            {
               
                vergi = _vergiDilimiManager.Get("minMaas <=" + toplamMaas.ToString() + " and maxMaas > " + toplamMaas.ToString()).vergiDilimi;
                agi = _agiManager.Get("agiId=" + kisi.agiId.ToString()).agiMiktari;
                vergiMuhafiyeti = _sakatlikManager.Get("sakatlikId=" + kisi.sakatlikId.ToString()).indirim;
                hesaplaModel = hesapla.BrüttenNete2(kisi.maas, vergi, agi, vergiMuhafiyeti);
                hesaplaModel.ay = ay;
                hesaplaModels.Add(hesaplaModel);
                toplamMaas += kisi.maas;
            }
            //foreach(var ay in _aylar)
            //{
            //    toplamMaas += kisi.maas;
            //    vergi = _vergiDilimiManager.Get("minMaas <=" + toplamMaas.ToString() + " and maxMaas > " + toplamMaas.ToString()).vergiDilimi;

            //    //hesaplaModel = hesapla.BrüttenNete(kisi.maas, vergi, vergiMuhafiyeti);
            //    hesaplaModel.ay = ay;
            //    hesaplaModels.Add(hesaplaModel);
            //}   
            return View("Hesapla", hesaplaModels);
            //var kisi = _kullaniciManager.GetById(id);
            //if (kisi != null)
            //    return View("Hesapla", kisi);
            //else
            //    return HttpNotFound();
        }
        [HttpGet]
        public ActionResult NET(int id)
        {
            double toplamMaas = 0;
            double vergi;
            double agi;
            double vergiMuhafiyeti;
            Kisiler kisi = new Kisiler();
            Hesapla hesapla = new Hesapla();
            List<double> data = new List<double>();
            kisi = _kisilerManager.Get("kisiId=" + id.ToString());
            HesaplaModel hesaplaModel = new HesaplaModel();
            List<HesaplaModel> hesaplaModels = new List<HesaplaModel>();
            ayEkle();

            foreach (var ay in _aylar)
            {
                
                vergi = _vergiDilimiManager.Get("minMaas <=" + toplamMaas.ToString() + " and maxMaas > " + toplamMaas.ToString()).vergiDilimi;
                agi = _agiManager.Get("agiId=" + kisi.agiId.ToString()).agiMiktari;
                vergiMuhafiyeti = _sakatlikManager.Get("sakatlikId=" + kisi.sakatlikId.ToString()).indirim;
                hesaplaModel = hesapla.NettenBrüte2(kisi.maas, vergi, agi, vergiMuhafiyeti);
                hesaplaModel.ay = ay;
                toplamMaas += Convert.ToInt32(hesaplaModel.brütMaas);
                hesaplaModels.Add(hesaplaModel);
                
            }
            //foreach(var ay in _aylar)
            //{
            //    toplamMaas += kisi.maas;
            //    vergi = _vergiDilimiManager.Get("minMaas <=" + toplamMaas.ToString() + " and maxMaas > " + toplamMaas.ToString()).vergiDilimi;

            //    //hesaplaModel = hesapla.BrüttenNete(kisi.maas, vergi, vergiMuhafiyeti);
            //    hesaplaModel.ay = ay;
            //    hesaplaModels.Add(hesaplaModel);
            //}   
            return View("Hesapla", hesaplaModels);
            //var kisi = _kullaniciManager.GetById(id);
            //if (kisi != null)
            //    return View("Hesapla", kisi);
            //else
            //    return HttpNotFound();
        }

        public ActionResult Sil(int id)
        {
            _kisilerManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}