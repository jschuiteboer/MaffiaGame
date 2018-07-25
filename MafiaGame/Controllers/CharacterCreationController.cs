using MafiaGame.Models;
using MafiaGame.Services;
using MafiaGame.ViewModels;
using System.Collections.Generic;
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
            return View(new CharacterCreationViewModel {
                StartingCities = this.GetStartingCities(),
            });
        }

        [HttpPost]
        public ActionResult Index(CharacterCreationViewModel model)
        {
            model.StartingCities = this.GetStartingCities();

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

        private List<SelectListItem> GetStartingCities()
        {
            var startingCities = new List<SelectListItem>();
            var cityNames = this._cityService.GetCityNames();

            foreach(var name in cityNames)
            {
                startingCities.Add(new SelectListItem { Text = name });
            }

            return startingCities;
        }
    }
}