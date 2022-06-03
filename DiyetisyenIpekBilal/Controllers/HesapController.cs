using DiyetisyenIpekBilal.Data;
using DiyetisyenIpekBilal.Models;
using DiyetisyenIpekBilal.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DiyetisyenIpekBilal.Controllers
{
    public class HesapController : Controller
    {
        private readonly DytIpekBilalDBContext _context;

        public HesapController(DytIpekBilalDBContext context)
        {
            _context = context;
        }

        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Giris([Bind("Emaill,Password")]GirisViewModel userr)
        {
            if (ModelState.IsValid)//html den gelen emaıl ve şifre girişmodel
            //kuralına uyuyorsa döngüye girer
            {

                ClaimsIdentity identityy = null;
                bool isAuthenticated = false;
                Userr userrr = await _context.Userrs.Include(k => k.Rolee).FirstOrDefaultAsync(m => m.Emaill == userr.Emaill && m.Password == userr.Password);
                //girdiği email ve şifre data da kayıtlı olanlara eşit olan kullanıcı anlamına gelir userrr 
                if (userrr == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Bulunamadı.");
                    return View();
                }


                //if (userrr.RoleeID == 2)
                //{
                //    return Redirect("~/Hesap/AktivasyonBilgilendirme"); burada return olduğu için burdan sonra kod çalışmıyor
                //}


                identityy = new ClaimsIdentity//giriş için gerekli olan bilgileri çerezde tutar, böylece her sayfada bilgilerini girmen gerekmez
                (new[]
                        {
                            new Claim(ClaimTypes.Sid,userrr.UserrID.ToString()),
                            new Claim(ClaimTypes.Email,userrr.Emaill),
                            new Claim(ClaimTypes.Role,userrr.Rolee.RoleeName),
                        }, CookieAuthenticationDefaults.AuthenticationScheme
                );



                isAuthenticated = true;

                if (isAuthenticated)
                {
                    var claimss = new ClaimsPrincipal(identityy);
                    var loginn = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimss,

                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.Now.AddMinutes(60)//giren adamın çerezi 60dk kalır
                        }

                        );



                    if (userrr.Rolee.RoleeName == "Admin")
                    {
                        return Redirect("~/Admin/Index");
                    }
                    else 
                    {
                        return Redirect("~/Hesap/Giris");

                    }



                }
                return View();
            }
            return View(userr);

        }

    }
}

