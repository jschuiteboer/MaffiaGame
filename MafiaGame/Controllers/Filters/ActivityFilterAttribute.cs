using Castle.Windsor;
using MafiaGame.Models;
using MafiaGame.Services;
using System;
using System.Web.Mvc;

namespace MafiaGame.Controllers.Activities
{
    public class ActivityAttribute : ActionFilterAttribute
    {
        private ITileService _tileService;

        private IPlayerService _playerService;

        public ActivityAttribute() : this(WindsorContainerHandler.Container)
        {
        }
        
        private ActivityAttribute(IWindsorContainer container)
        {
            this._tileService = container.Resolve<ITileService>();
            this._playerService = container.Resolve<IPlayerService>();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Guid tileId = Guid.Parse(context.RouteData.Values["id"].ToString());

            Tile tile = _tileService.GetTileFromId(tileId);

            PlayerEntity player = _playerService.GetCurrent();

            if(!tile.Position.Equals(player.CurrentTile.Position))
            {
                throw new InvalidOperationException();
            }

            // TODO: only allow actions on the current tile
            // TODO: only allow travel to action on neighbouring tiles
        }
    }
}