using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class OrderItem
    {
        public OrderItem(int ıtemId, decimal unitPrice, int quantity, decimal total)
        {
            ItemId = ıtemId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Total = total;
        }

        public int Id { get; set; }
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
    }
}
