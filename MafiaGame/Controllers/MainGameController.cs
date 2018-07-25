using MafiaGame.Models;
using MafiaGame.Services;
using System.Web.Mvc;

namespace MafiaGame.Controllers
{
    public class MainGameController : Controller
    {
        private IPlayerService _playerService;

        public MainGameController(IPlayerService playerService)
        {
            this._playerService = playerService;
        }

        //TODO: use viewmodel here
        public ActionResult Index()
        {
            PlayerEntity player = _playerService.GetCurrent();

            ViewData["player"] = player;
            ViewData["map"] = player.City.Map;

            return View();
        }
    }
}