using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI._1._0.Core.Model;
using WebUI._1._0.Models;

namespace WebUI._1._0.Controllers
{
    public class AuthController : Controller
    {
        public SignInManager<ExtendedUser, string> signInManager => HttpContext.GetOwinContext().Get<SignInManager<ExtendedUser, string>>();
            
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, true,true);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");                
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
    }
}