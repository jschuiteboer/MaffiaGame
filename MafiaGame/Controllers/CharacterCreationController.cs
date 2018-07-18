using MafiaGame.ViewModels;
using System.Web.Mvc;

namespace MafiaGame.Controllers
{
    public class CharacterCreationController : Controller
    {
        public ActionResult Index()
        {
            return View(new CharacterCreationViewModel());
        }
        
        [HttpPost]
        public ActionResult Index(CharacterCreationViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction(null, "MainGame");
            }
        }

        
    }
}