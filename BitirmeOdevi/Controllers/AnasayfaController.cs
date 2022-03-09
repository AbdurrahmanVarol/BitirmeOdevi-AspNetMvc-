using BitirmeOdevi.Business.Abstract;
using BitirmeOdevi.Business.Concrate;
using BitirmeOdevi.DataAccess.Concrate;
using BitirmeOdevi.DataAccess.Concrate.EntityFramework;
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
    public class AnasayfaController : Controller
    {
        
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

        // GET: Anasayfa
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult BRÜT(kisiModel kisiModel)
        {
            double toplamMaas = 0;
            double vergi;
            double agi;
            double vergiMuhafiyeti;
            
            
            List<HesaplaModel> hesaplaModels = new List<HesaplaModel>();
            AyEkle();
           
            if (kisiModel.medeniDurum == "Bekar" || kisiModel.medeniDurum == "Faydalanmayacak")
                agi = _agiManager.GetByCondition(kisiModel.medeniDurum).agiMiktari;
            else
            {
                if(kisiModel.cocukSayisi >= 5)
                    agi = _agiManager.GetByConditionAndChild(kisiModel.medeniDurum,5).agiMiktari;
                else
                    agi = _agiManager.GetByConditionAndChild(kisiModel.medeniDurum, kisiModel.cocukSayisi).agiMiktari;
            }

            vergiMuhafiyeti = _sakatlikManager.Get(kisiModel.sakatlikId).indirim;
            foreach (var ay in _aylar)
            {

                vergi = _vergiDilimiManager.GetByTotalSalary(toplamMaas).vergiDilimi;
                

                HesaplaModel hesaplaModel = new HesaplaModel();
                _hesapla.BrüttenNete(hesaplaModel, kisiModel.maas, vergi, agi, vergiMuhafiyeti, kisiModel.sigortaId);
                hesaplaModel.ay = ay;
                hesaplaModels.Add(hesaplaModel);
                toplamMaas += kisiModel.maas;
            }
            return Json(hesaplaModels, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult NET(kisiModel kisiModel)
        {
            double toplamMaas = 0;
            double vergi;
            double agi;
            double vergiMuhafiyeti;

            List<HesaplaModel> hesaplaModels = new List<HesaplaModel>();
            AyEkle();
            if (kisiModel.medeniDurum == "Bekar" || kisiModel.medeniDurum == "Faydalanmayacak")
                agi = _agiManager.GetByCondition(kisiModel.medeniDurum).agiMiktari;
            else
            {
                if (kisiModel.cocukSayisi >= 5)
                    agi = _agiManager.GetByConditionAndChild(kisiModel.medeniDurum, 5).agiMiktari;
                else
                    agi = _agiManager.GetByConditionAndChild(kisiModel.medeniDurum, kisiModel.cocukSayisi).agiMiktari;
            }

            vergiMuhafiyeti = _sakatlikManager.Get(kisiModel.sakatlikId).indirim;
            foreach (var ay in _aylar)
            {

                vergi = _vergiDilimiManager.GetByTotalSalary(toplamMaas).vergiDilimi;
                HesaplaModel hesaplaModel = new HesaplaModel();
                _hesapla.NettenBrüte(hesaplaModel, kisiModel.maas, vergi, agi, vergiMuhafiyeti, kisiModel.sigortaId);
                hesaplaModel.ay = ay;
                hesaplaModels.Add(hesaplaModel);
                toplamMaas += kisiModel.maas;
            }
            return Json(hesaplaModels, JsonRequestBehavior.AllowGet);
        }
    }
}