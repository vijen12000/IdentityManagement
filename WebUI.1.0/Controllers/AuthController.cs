using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI._1._0.Core;
using WebUI._1._0.Core.Model;
using WebUI._1._0.Models;

namespace WebUI._1._0.Controllers
{
    public class AuthController : Controller
    {        
        private readonly AppUserManager _userManager;
        private readonly AppSignInManager _signInManager;

        public AuthController(AppUserManager userManager, AppSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

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
            
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true,true);
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
            var user =await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user.Id.ToString());
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
            var identityModel = await _userManager.ResetPasswordAsync(model.UserId, model.Token, model.Password);
            if (!identityModel.Succeeded)
            {
                return View("Error");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}