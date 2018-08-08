using MafiaGame.Models;
using MafiaGame.Services;
using MafiaGame.Util;
using MafiaGame.ViewModels;
using System.Web.Mvc;

namespace MafiaGame.Controllers
{
    public class CharacterCreationController : Controller
    {
        private IPlayerService _playerService;

        private ICityService _cityService;

        public CharacterCreationController(IPlayerService playerService, ICityService cityService)
        {
            this._playerService = playerService;
            this._cityService = cityService;
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
                this._playerService.InitPlayer(model.Name, model.SelectedStartingCity);

                return RedirectToAction(null, "MainGame");
            }
        }

        protected ViewResult View(CharacterCreationViewModel model)
        {
            model.StartingCities = ViewUtil.ToOptionList(this._cityService.GetCities(), city => city.Name);

            return base.View(model);
        }
    }
}