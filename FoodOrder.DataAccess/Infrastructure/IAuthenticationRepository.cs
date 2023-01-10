using FoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.DataAccess.Infrastructure
{
    public interface IAuthenticationRepository
    {
        bool CreateUser(User user, string Password);
        Task<bool> SignOut();
        User AuthenticateUser(string username, string Password);
        User GetUser(string username);  
    }
}
