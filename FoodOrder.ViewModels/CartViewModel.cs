using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.ViewModels
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal GrandTotal { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<ItemViewModel> Items { get; set; } = new List<ItemViewModel>();
    }
}
