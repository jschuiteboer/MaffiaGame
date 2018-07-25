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

        public ActionResult Index()
        {
            PlayerEntity player = PlayerService.GetCurrent();

            ViewData["name"] = player.Name;

            return View();
        }
    }
}