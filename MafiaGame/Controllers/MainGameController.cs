using MafiaGame.Models;
using MafiaGame.Services;
using System.Web.Mvc;

namespace MafiaGame.Controllers
{
    public class MainGameController : Controller
    {
        private IPlayerService PlayerService;

        public MainGameController(IPlayerService playerService)
        {
            this.PlayerService = playerService;
        }

        //TODO: use viewmodel here
        public ActionResult Index()
        {
            PlayerEntity player = PlayerService.GetCurrent();

            ViewData["player"] = player;

            return View();
        }
    }
}