using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {        
        public UserController(UserService userManager, SignInService signInManager):base(userManager,signInManager)
        {            
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
        
        public ActionResult Edit(UserEditViewModel user)
        {            
            return RedirectToAction("Index");
        }
                
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
        
        public ActionResult AddRolesToUser(int id,List<int> roles)
        {
            return RedirectToAction("Index");
        }
              
        public async Task<ActionResult> AddUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            return View(model);
        }

        private ActionResult AddRightsToRole(int id, List<int> rights)
        {
            return View();
        }
    }
}