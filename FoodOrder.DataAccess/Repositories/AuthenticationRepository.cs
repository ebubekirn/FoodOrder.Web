using FoodOrder.DataAccess.Infrastructure;
using FoodOrder.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.DataAccess.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        protected SignInManager<User> _signManager;
        protected UserManager<User> _userMenager; 
        protected RoleManager<Role> _roleMenager;
        public AuthenticationRepository(SignInManager<User> signManager, UserManager<User> userMenager, RoleManager<Role> roleMenager)
        {
            _signManager = signManager;
            _userMenager = userMenager;
            _roleMenager = roleMenager;
        }

        public User AuthenticateUser(string username, string Password)
        {
            var result = _signManager.PasswordSignInAsync(username, Password, false, lockoutOnFailure:false).Result;
            if (result.Succeeded)
            {
                var user = _userMenager.FindByNameAsync(username).Result;
                var roles = _userMenager.GetRolesAsync(user).Result;
                user.Roles = roles.ToArray();

                return user;
            }
            return null;
        }

        public bool CreateUser(User user, string Password)
        {
            var result = _userMenager.CreateAsync(user, Password).Result;
            if (result.Succeeded)
            {
                string role = "User";
                var res = _userMenager.AddToRoleAsync(user, role).Result;
                if (res.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public User GetUser(string username)
        {
            return _userMenager.FindByNameAsync(username).Result;
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await _signManager.SignOutAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
