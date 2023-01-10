using FoodOrder.DataAccess.Infrastructure;
using FoodOrder.Models;
using FoodOrder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FoodOrderUI.Web.Controllers
{
    public class AccountController : Controller
    {
        IAuthenticationRepository _authRepository;
        public AccountController(IAuthenticationRepository AuthRepository)
        {
            _authRepository = AuthRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _authRepository.AuthenticateUser(model.Email, model.Password);
                if (user != null)
                {
                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)) 
                    return Redirect(returnUrl);

                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin"});
                    }
                    else if (user.Roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "User" });
                    }
                }
            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                bool result = _authRepository.CreateUser(user, model.Password);
                if (result)
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public async Task<IActionResult> SignOut()
        {
            await _authRepository.SignOut();
            return RedirectToAction("Index", "Home");
        }
        /* video 3 7:00
        public async Task<IActionResult> LogOut()
        {
            await _authRepository.SignOut();
            return RedirectToAction("LogOutComplete");
        }

        public IActionResult LogOutComplete()
        {
            return View();
        }
        */
    }
}
