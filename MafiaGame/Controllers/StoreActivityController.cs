using System.Web.Mvc;

namespace MafiaGame.Controllers.Activities
{
    [Activity]
    public class StoreActivityController : Controller
    {
        public ActionResult Rob()
        {
            return View();
        }
    }
}