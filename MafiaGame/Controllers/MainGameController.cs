using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MafiaGame.Controllers
{
    public class MainGameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}