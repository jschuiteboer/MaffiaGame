using MafiaGame.Models;
using MafiaGame.Services;
using System.Web.Mvc;
using System.Windows;

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
            ViewData["map"] = this.CreateBasicMap();

            return View();
        }

        private Map CreateBasicMap()
        {
            Map map = new Map();

            map.TileList.Add(new Tile()
            {
                Position = new Point(50, 50)
            });

            map.TileList.Add(new Tile()
            {
                Position = new Point(30, 20)
            });

            map.TileList.Add(new Tile()
            {
                Position = new Point(60, 10)
            });

            return map;
        }
    }
}