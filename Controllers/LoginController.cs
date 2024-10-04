using Microsoft.AspNetCore.Mvc;
using ProjectMVCv._2.Helpers;
using ProjectMVCv._2.Models;
using ProjectMVCv._2.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectMVCv._2.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _IUserRepository;
        private readonly IUserSession _IUserSession;

        public LoginController(IUserRepository userRepository, IUserSession iUserSession)
        {
            _IUserRepository = userRepository;
            _IUserSession = iUserSession;
        }


        public IActionResult Index()
        {
            // Se User estiver logado, redirecionar para home

            if (_IUserSession.GetUserSession() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult CreateRegister() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterModel registerModel)
        {           
            try
            {
                if (ModelState.IsValid) 
                {
                    TempData["MensagemSucesso"] = "User register success!";
                    await _IUserRepository.Create(registerModel);                   
                    return RedirectToAction("Index", "Login");
                }
                TempData["MensagemErro"] = $"Your email needs an @ and a valid domain .com for example!";
                return RedirectToAction("CreateRegister", "Login");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! User register fail!, error detail: {erro.Message}"; 
                return RedirectToAction("CreateRegister", "Login");
            }           
        }

        public IActionResult ExitSession() 
        {
            _IUserSession.RemoveUserSession();
            return RedirectToAction("Index","Login");
        }

        [HttpPost]
        public async Task<ActionResult<User>> LoginConfirm(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = _IUserRepository.GetById(loginModel);                   

                    if (user != null) 
                    {
                        if (user.CheckPassword(loginModel.Password))
                        {
                            _IUserSession.CreateUserSession(user);                       
                            return RedirectToAction("Index", "Home", user);
                        }

                        TempData["MensagemErro"] = $"Password is invalid. Please, try again!";
                    }

                    TempData["MensagemErro"] = $"User our Password is invalid. Please, try again!";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, We can't log you in, try again, erro detail: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPasswordConfirm(LoginModel loginModel)
        {
            try
            {
                if (loginModel.Email != null)
                {
                    User user = _IUserRepository.GetById(loginModel);

                    if (user != null)
                    {
                        string newPassword = user.CreateNewPassword();
                        user.Password = newPassword;
                        _IUserRepository.UpdatePassword(user);
                        TempData["MensagemSuccess"] = $"We will send a new password to your email. Check your email.";
                        return RedirectToAction("Index","Login");
                    }

                    TempData["MensagemErro"] = $"This email does not exist. Please, try again!";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, We can't reset your password, try again, erro detail: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }
    }
}
