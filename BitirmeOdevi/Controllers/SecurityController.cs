using BitirmeOdevi.Business.Abstract;
using BitirmeOdevi.Business.Concrate;
using BitirmeOdevi.DataAccess.Abstract;
using BitirmeOdevi.DataAccess.Concrate;
using BitirmeOdevi.DataAccess.Concrate.EntityFramework;
using BitirmeOdevi.Entities;
using BitirmeOdevi.Entities.Concrate;
using BitirmeOdevi.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BitirmeOdevi.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Login
        IKullaniciService _kullaniciManager = new KullaniciManager(new EfKullaniciDal());
        public Kullanici login;
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {

            // cookieVisitor.Expires = DateTime.Now.AddDays(2);

            var kullanici = _kullaniciManager.GetByUserNameAndPassword(user.userName, user.password);
            if (kullanici != null)
            {
                if (user.userName == kullanici.kullaniciAd && user.password == kullanici.sifre)
                {
                    HttpCookie cookieLogin = new HttpCookie("Login", kullanici.id.ToString());
                    Response.Cookies.Add(cookieLogin);
                    //FormsAuthentication.SetAuthCookie("2", false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Mesaj = "Kullanıcı adı ya da şifre yanlış.";
                    return View();
                }

            }
            else
            {
                user.loginErronMeggase = "Kullanıcı adı ya da şifre yanlış.";
                return View();
            }

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(userModel userModel)
        {
            var varMi = _kullaniciManager.GetByUserName(userModel.kullaniciAd);
            if (varMi == null)
            {
                if (userModel.sifre == userModel.sifreTekrar)
                {
                    Kullanici kullanici = new Kullanici()
                    {
                        ad = userModel.ad,
                        soyad = userModel.soyad,
                        kullaniciAd = userModel.kullaniciAd,
                        sifre = userModel.sifre,
                        email = userModel.email,
                        yetkiId = userModel.yetkiId
                    };
                    _kullaniciManager.Add(kullanici);
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.sifreMEsaj = "Girdiğiniz şifreler eşleşmedi. Tekrar deneyin.";
                    return View();
                }
                    
               
            }
            else
            {
                ViewBag.kullaniciMesaj = "Böyle bir kullanıcı zaten var!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["Login"] != null)
            {
                Response.Cookies["Login"].Expires = DateTime.Now.AddDays(-1);
            }

            return RedirectToAction("Login");
        }
    }
}