using MafiaGame.Models;
using MafiaGame.Services;
using MafiaGame.ViewModels;
using System.Web.Mvc;

namespace MafiaGame.Controllers
{
    public class CharacterCreationController : Controller
    {
        private IPlayerService PlayerService;

        public CharacterCreationController(IPlayerService playerService)
        {
            this.PlayerService = playerService;
        }

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
                PlayerEntity player = PlayerService.GetCurrent();
                player.Name = model.Name;

                return RedirectToAction(null, "MainGame");
            }
        }
    }
}