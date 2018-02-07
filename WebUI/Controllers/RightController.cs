using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class RightController : BaseController
    {
        public RightController(UserService userManager, SignInService signInManager) : base(userManager, signInManager)
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

        public ActionResult Edit(RightViewModel right)
        {            
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
        
        public ActionResult AddRight(RightViewModel right)
        {
            return RedirectToAction("Index");
        }

        public ActionResult AddUsersToRight(int id, List<int> users)
        {         
            return View();
        }

        public ActionResult AddRightsToUser(int id, List<int> rights)
        {         
            return View();
        }
    }
}