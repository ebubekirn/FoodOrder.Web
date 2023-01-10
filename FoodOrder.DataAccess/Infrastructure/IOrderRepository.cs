using FoodOrder.Models;
using FoodOrder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.DataAccess.Infrastructure
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetOrders(int UserId);
        OrderViewModel GetOrderDetails(string id);
        PagingList<OrderViewModel> GetOrderList(int page, int pageSize);
    }
}
