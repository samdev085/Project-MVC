using ProjectMVCv._2.Models;

namespace ProjectMVCv._2.Helpers
{
    public interface IUserSession
    {
        void CreateUserSession(User user);
        void RemoveUserSession();
        User GetUserSession();
    }
}
