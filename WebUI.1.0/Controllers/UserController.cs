using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI._1._0.Models;
using System.Threading.Tasks;
using WebUI._1._0.Core.Model;
using WebUI._1._0.Core;

namespace WebUI._1._0.Controllers
{
    public class UserController : Controller
    {
        private readonly AppUserManager _userManager;

        public UserController(AppUserManager userManager)
        {
            this._userManager = userManager;
        }

        public ActionResult Index()
        {
            var users = _userManager.Users;

            return View(users);            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            var identiyUser = await _userManager.FindByNameAsync(model.UserName);
            if (identiyUser != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = new ExtendedUser
            {
                UserName = model.UserName,
                FullName = model.FullName
            };
            
            var result = await _userManager.CreateAsync(user, model.Password);

            //Genrate Token
            var token = _userManager.GenerateEmailConfirmationTokenAsync(user.Id);
            var confirmUrl = Url.Action("ConfirmEmail", "Account", new { userid = user.Id, token = token }, Request.Url.Scheme);

            await _userManager.SendEmailAsync(user.Id, "Email Confirmation", $"Use link to confirm email:{confirmUrl}");

            if (result.Succeeded) return RedirectToAction("Index", "Home");
            ModelState.AddModelError("", result.Errors.FirstOrDefault());
            return View(model);
        }

        public async Task<ActionResult> ConfirmEmail(string userId, string token)
        {
            var result = await _userManager.ConfirmEmailAsync(userId, token);
            if (result.Succeeded)
            {
                return View("Error");
            }
            return RedirectToAction("Index", "Home");
        }       
    }
}