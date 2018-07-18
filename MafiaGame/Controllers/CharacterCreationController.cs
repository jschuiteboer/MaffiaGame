using MafiaGame.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MafiaGame.Controllers
{
    public class CharacterCreationController : Controller
    {
        public ActionResult Index()
        {
            return View(new CharacterCreationViewModel());
        }

        // TODO: show error messages
        [HttpPost]
        public ActionResult Index(CharacterCreationViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                //TODO: process model variables

                return View(model);
            }
        }

        
    }
}