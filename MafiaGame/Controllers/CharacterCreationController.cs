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
                PlayerEntity player = this._playerService.GetCurrent();
                player.Name = model.Name;
                player.City = this._cityService.GetCityFromName(model.SelectedStartingCity);

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