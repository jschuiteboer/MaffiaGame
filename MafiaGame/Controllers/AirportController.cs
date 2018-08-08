using System.Web.Mvc;

namespace MafiaGame.Controllers.Activities
{
    public class AirportController : Controller
    {
        public ActionResult Travel()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Travel(string location)
        {

            return View();
        }
    }
}