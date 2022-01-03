using BitirmeOdevi.Business.Concrate;
using BitirmeOdevi.DataAccess.Concrate;
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
        KullaniciManager _kullaniciManager = new KullaniciManager(new KullaniciDal());
        KisilerManager _kisilerManager = new KisilerManager(new KisilerDal());
        VergiDilimiManager _vergiDilimiManager = new VergiDilimiManager(new VergiDilimiDal());
        AgiManager _agiManager = new AgiManager(new AgiDal());
        SigortaManager _sigortaManager = new SigortaManager(new SigortaDal());
        SakatlikManager _sakatlikManager = new SakatlikManager(new SakatlikDal());
        List<string> _aylar = new List<string>();

        public void ayEkle()
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
            
            Hesapla hesapla = new Hesapla();
            List<HesaplaModel> hesaplaModels = new List<HesaplaModel>();
            ayEkle();
            string agiSorgu = "";
            if (kisiModel.medeniDurum == "Bekar" || kisiModel.medeniDurum == "Faydalanmayacak")
                agiSorgu = "medeniDurum='" + kisiModel.medeniDurum +"'";
            else
            {
                if(kisiModel.cocukSayisi >= 5)
                    agiSorgu = "medeniDurum='" + kisiModel.medeniDurum + "' and cocukSayisi = " + 5.ToString();
                else
                    agiSorgu = "medeniDurum='" + kisiModel.medeniDurum + "' and cocukSayisi = " + kisiModel.cocukSayisi.ToString();
            }

            agi = _agiManager.Get(agiSorgu).agiMiktari;
            vergiMuhafiyeti = _sakatlikManager.Get("sakatlikId=" + kisiModel.sakatlikId.ToString()).indirim;
            foreach (var ay in _aylar)
            {

                vergi = _vergiDilimiManager.Get("minMaas <=" + toplamMaas.ToString() + " and maxMaas > " + toplamMaas.ToString()).vergiDilimi;               
                HesaplaModel hesaplaModel = new HesaplaModel();
                hesapla.BrüttenNete(hesaplaModel, kisiModel.maas, vergi, agi, vergiMuhafiyeti, kisiModel.sigortaId);
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

            Hesapla hesapla = new Hesapla();
            List<HesaplaModel> hesaplaModels = new List<HesaplaModel>();
            ayEkle();
            string agiSorgu = "";
            if (kisiModel.medeniDurum == "Bekar" || kisiModel.medeniDurum == "Faydalanmayacak")
                agiSorgu = "medeniDurum='" + kisiModel.medeniDurum + "'";
            else
            {
                if (kisiModel.cocukSayisi >= 5)
                    agiSorgu = "medeniDurum='" + kisiModel.medeniDurum + "' and cocukSayisi = " + 5.ToString();
                else
                    agiSorgu = "medeniDurum='" + kisiModel.medeniDurum + "' and cocukSayisi = " + kisiModel.cocukSayisi.ToString();
            }

            agi = _agiManager.Get(agiSorgu).agiMiktari;
            vergiMuhafiyeti = _sakatlikManager.Get("sakatlikId=" + kisiModel.sakatlikId.ToString()).indirim;
            foreach (var ay in _aylar)
            {

                vergi = _vergiDilimiManager.Get("minMaas <=" + toplamMaas.ToString() + " and maxMaas > " + toplamMaas.ToString()).vergiDilimi;
                HesaplaModel hesaplaModel = new HesaplaModel();
                hesapla.NettenBrüte(hesaplaModel, kisiModel.maas, vergi, agi, vergiMuhafiyeti, kisiModel.sigortaId);
                hesaplaModel.ay = ay;
                hesaplaModels.Add(hesaplaModel);
                toplamMaas += kisiModel.maas;
            }
            return Json(hesaplaModels, JsonRequestBehavior.AllowGet);
        }
    }
}