using Microsoft.EntityFrameworkCore.Storage.Json;
using ProjectMVCv._2.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectMVCv._2.Helpers
{
    public class UserSession : IUserSession
    {

        private readonly IHttpContextAccessor _httpContext;

        public UserSession(IHttpContextAccessor httpContext) 
        {
            _httpContext = httpContext;
        }


        public void CreateUserSession(User user)
        {
            string value = JsonSerializer.Serialize(user);
            _httpContext.HttpContext.Session.SetString("sessionUserLogged", value);
        }
        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("sessionUserLogged");
        }
        public User GetUserSession()
        {
            string sessionUser = _httpContext.HttpContext.Session.GetString("sessionUserLogged");

            if (string.IsNullOrEmpty(sessionUser)) return null;

            User user = JsonSerializer.Deserialize<User>(sessionUser);

            return user;
        }       
        
    }
}
