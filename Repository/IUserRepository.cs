using ProjectMVCv._2.Models;

namespace ProjectMVCv._2.Repository
{
    public interface IUserRepository
    {
        User GetById(LoginModel login);
        
        Task<User> Create(RegisterModel registerModel);

        Task<User> UpdatePassword(User user);
    }
}
