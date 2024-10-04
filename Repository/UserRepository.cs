using Microsoft.EntityFrameworkCore;
using ProjectMVCv._2.Data;
using ProjectMVCv._2.Models;

namespace ProjectMVCv._2.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _optionsbuilder;


        public UserRepository(Context optionsbuilder)
        {
            _optionsbuilder = optionsbuilder;
        }


        public async Task<User> Create(RegisterModel registerModel)
        {
            User user = new User()
            {
                Name = registerModel.Name,
                Email = registerModel.Email,
                Password = registerModel.Password
            };
            user.SetHashPassword();
            await _optionsbuilder.Users.AddAsync(user);
            await _optionsbuilder.SaveChangesAsync();

            return user;
        }

        public User GetById(LoginModel login)
        {
            var user = _optionsbuilder.Users.FirstOrDefault(x => x.Email.ToUpper() == login.Email.ToUpper());
            return user;
        }

        public async Task<User> UpdatePassword(User user)
        {
            _optionsbuilder.Users.Update(user);
            _optionsbuilder.SaveChanges();
            User userUpdated =  _optionsbuilder.Users.Find(user.Email);
            return userUpdated;
        }
    }
}
