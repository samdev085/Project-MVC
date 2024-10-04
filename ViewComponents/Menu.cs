using Microsoft.AspNetCore.Mvc;
using ProjectMVCv._2.Models;
using System.Text.Json;

namespace ProjectMVCv._2.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessionUser = HttpContext.Session.GetString("sessionUserLogged");

            if (string.IsNullOrEmpty(sessionUser)) return null;
            
            User user = JsonSerializer.Deserialize<User>(sessionUser);


            return View(user);
        }
    }
}
