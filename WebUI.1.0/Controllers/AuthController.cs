using Microsoft.AspNet.Identity;
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
        public UserManager<ExtendedUser> userManager => HttpContext.GetOwinContext().Get<UserManager<ExtendedUser>>();
            
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

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            var user =await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user.Id.ToString());
                var requestUrl = Url.Action("PasswordReset", "Auth", new { userId = user.Id, token = token }, Request.Url.Scheme);
                //await userManager.SendEmailAsync(user.Id.ToString(), "Password Reset", $"Use this link to reset Password:{requestUrl}");
                ViewBag.Url = requestUrl;
                return View("TempLink");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult PasswordReset(string userId, string token)
        {
            return View(new PasswordResetModel { UserId = userId, Token = token });
        }

        [HttpPost]
        public async Task<ActionResult> PasswordReset(PasswordResetModel model)
        {
            var identityModel = await userManager.ResetPasswordAsync(model.UserId, model.Token, model.Password);
            if (!identityModel.Succeeded)
            {
                return View("Error");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}