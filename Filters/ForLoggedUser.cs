using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectMVCv._2.Models;
using System.Text.Json;

namespace ProjectMVCv._2.Filters
{
    public class ForLoggedUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userSession = context.HttpContext.Session.GetString("sessionUserLogged");

            if (string.IsNullOrEmpty(userSession)) 
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary {{"controller","Login"},{"action","Index"}});
            }
            else 
            { 
                User user = JsonSerializer.Deserialize<User>(userSession);
                if (user == null) 
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
