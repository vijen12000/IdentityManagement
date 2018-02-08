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

namespace WebUI._1._0.Controllers
{
    public class UserController : Controller
    {
        public UserManager<IdentityUser> userManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();

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
            var result = await userManager.CreateAsync(new IdentityUser(model.UserName), model.Password);
            if (result.Succeeded) return RedirectToAction("Index", "Home");
            ModelState.AddModelError("", result.Errors.FirstOrDefault());
            return View(model);
        }
    }
}