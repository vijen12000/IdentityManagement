using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class RoleController : BaseController
    {
        public RoleController(UserService userManager, SignInService signInManager) : base(userManager, signInManager)
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
                
        public ActionResult Edit(RoleEditViewModel role)
        {                        
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int id)
        {                     
            return View();
        }
                
        public ActionResult AddRole(RoleCreateViewModel role)
        {
            return RedirectToAction("Index");
        }

        public ActionResult AddUsersToRole(int id,List<int> users)
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult AddRightsToRole(int id, List<int> rights)
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
