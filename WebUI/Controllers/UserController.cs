using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {

        public UserController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}