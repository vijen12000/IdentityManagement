using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI._1._0.Models;
using System.Threading.Tasks;
using WebUI._1._0.Core.Model;

namespace WebUI._1._0.Controllers
{
    public class UserController : Controller
    {
        //public UserManager<IdentityUser> userManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();
        public UserManager<ExtendedUser> userManager => HttpContext.GetOwinContext().Get<UserManager<ExtendedUser>>();

        public UserController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            var identiyUser = await userManager.FindByNameAsync(model.UserName);
            if (identiyUser != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = new ExtendedUser
            {
                UserName = model.UserName,
                FullName = model.FullName
            };
            user.Addresses.Add(new Address
            {
                AddressLine = model.AddressLine,
                Country = model.Country,
                UserId = user.Id
            });

            var result = await userManager.CreateAsync(user, model.Password);

            //Genrate Token
            var token = userManager.GenerateEmailConfirmationTokenAsync(user.Id);
            var confirmUrl = Url.Action("ConfirmEmail", "Account", new { userid = user.Id, token = token }, Request.Url.Scheme);

            await
                 userManager.SendEmailAsync(user.Id, "Email Confirmation", $"Use link to confirm email:{confirmUrl}");

            if (result.Succeeded) return RedirectToAction("Index", "Home");
            ModelState.AddModelError("", result.Errors.FirstOrDefault());
            return View(model);
        }

        public async Task<ActionResult> ConfirmEmail(string userId, string token)
        {
            var result = await userManager.ConfirmEmailAsync(userId, token);
            if (result.Succeeded)
            {
                return View("Error");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            var user = userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user.Id.ToString());
                var requestUrl = Url.Action("PasswordReset", "Auth", new { userId = user.Id, token = token }, Request.Url.Scheme);
                await userManager.SendEmailAsync(user.Id.ToString(), $"Password Reset", "Use this link to reset Password:{requestUrl}");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}