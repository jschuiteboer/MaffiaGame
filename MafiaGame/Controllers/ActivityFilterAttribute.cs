using System.Web.Mvc;

namespace MafiaGame.Controllers.Activities
{
    public class ActivityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // TODO: only allow actions on the current tile
            // TODO: only allow travel to action on neighbouring tiles
        }
    }
}