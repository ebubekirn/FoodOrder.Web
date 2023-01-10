using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoodOrder.Models
{
    public class CartItem
    {
        public CartItem(int ıtemId, decimal unitPrice, int quantity)
        {
            ItemId = ıtemId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public Guid CartId { get; set; }
        public Guid guid { get; set; }
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public Cart Cart { get; set; }
    }
}
