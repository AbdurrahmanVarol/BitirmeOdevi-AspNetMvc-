using BitirmeOdevi.Business.Abstract;
using BitirmeOdevi.Business.Concrate;
using BitirmeOdevi.DataAccess.Concrate;
using BitirmeOdevi.DataAccess.Concrate.EntityFramework;
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
       
        IKisilerService _kisilerManager = new KisilerManager(new EfKisilerDal());
        IVergiDİlimiService _vergiDilimiManager = new VergiDilimiManager(new EfVergiDilimiDal());
        IAgiService _agiManager = new AgiManager(new EfAgiDal());
        ISakatlikService _sakatlikManager = new SakatlikManager(new EfSakatlikDal());
        List<string> _aylar = new List<string>();
        IHesapla _hesapla = new Hesapla();

        public void AyEkle()
        {
            _aylar.Clear();
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
               
                List<kisiModel> kisiModels = new List<kisiModel>();
                int Id = Convert.ToInt32(Request.Cookies["Login"].Value);
                List<Kisiler> kisiDatabase = _kisilerManager.GetAllByUserId(Id);
                
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

        [HttpGet]
        public ActionResult Ekle()
        {
            if (Request.Cookies.AllKeys.Contains("Login"))
            {
                return View("kisiEkle");
            }
            else
                return RedirectToAction("Login", "Security");
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
                kisi.agiId = _agiManager.GetByConditionAndChild(kisiModel.medeniDurum,kisiModel.cocukSayisi).agiId;

            if (kisiModel.id != 0)
                _kisilerManager.Update(kisi);
            else
                _kisilerManager.Add(kisi);
            
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Düzenle(int id)
        {
            if (Request.Cookies.AllKeys.Contains("Login"))
            {
                var kisi = _kisilerManager.Get(id);
                var agi = _agiManager.Get(kisi.agiId);

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
            else
                return RedirectToAction("Login", "Security");
           
        }
        [HttpPost]
        public JsonResult BRÜT(int id)
        {
            double toplamMaas = 0;
            double vergi;
            double agi;
            double vergiMuhafiyeti;
            List<HesaplaModel> hesaplaModels = new List<HesaplaModel>();

            Kisiler kisi = _kisilerManager.Get(id);
            agi = _agiManager.Get(kisi.agiId).agiMiktari;
            vergiMuhafiyeti = _sakatlikManager.Get(kisi.sakatlikId).indirim;
            
            AyEkle();

            foreach (var ay in _aylar)
            {

                vergi = _vergiDilimiManager.GetByTotalSalary(toplamMaas).vergiDilimi;
                HesaplaModel hesaplaModel = new HesaplaModel();
                _hesapla.BrüttenNete(hesaplaModel, kisi.maas, vergi, agi, vergiMuhafiyeti, kisi.sigortaId);
                hesaplaModel.ay = ay;
                hesaplaModels.Add(hesaplaModel);
                toplamMaas += kisi.maas;
            }
            return Json(hesaplaModels,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult NET(int id)
        {
            double toplamMaas = 0;
            double vergi;
            double agi;
            double vergiMuhafiyeti;
            List<HesaplaModel> hesaplaModels = new List<HesaplaModel>();

            Kisiler kisi = _kisilerManager.Get(id);
            agi = _agiManager.Get(kisi.agiId).agiMiktari;
            vergiMuhafiyeti = _sakatlikManager.Get(kisi.sakatlikId).indirim;

            AyEkle();

            foreach (var ay in _aylar)
            {

                vergi = _vergiDilimiManager.GetByTotalSalary(toplamMaas).vergiDilimi;
                HesaplaModel hesaplaModel = new HesaplaModel();
                _hesapla.NettenBrüte(hesaplaModel, kisi.maas, vergi, agi, vergiMuhafiyeti, kisi.sigortaId);
                hesaplaModel.ay = ay;
                toplamMaas += Convert.ToInt32(hesaplaModel.brütMaas);
                hesaplaModels.Add(hesaplaModel);

            }
            return Json(hesaplaModels, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Sil(int id)
        {
            _kisilerManager.Delete(_kisilerManager.Get(id));
            return RedirectToAction("Index");
        }
    }
}