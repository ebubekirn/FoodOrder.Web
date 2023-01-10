using FoodOrder.Models;
using FoodOrder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.DataAccess.Infrastructure
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetCartById(Guid CartId);
        CartViewModel GetCartDetails(Guid CartId);
        int Delete(Guid CartId, int itemId);
        int UpdateQty(Guid CartId, int itemId, int Quantity);
        int UpdateCart(Guid CartId, int userId);
    }
}
