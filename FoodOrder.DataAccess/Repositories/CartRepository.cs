using FoodOrder.DataAccess.Infrastructure;
using FoodOrder.Models;
using FoodOrder.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.DataAccess.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;   
        }

        public int Delete(Guid cartId, int itemId)
        {
            var item = _context.CartItems.Where(x => x.CartId == cartId && x.Id == itemId).FirstOrDefault();

            if (item != null)
            {
                _context.CartItems.Remove(item);
                return _context.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public Cart GetCartById(Guid CartId)
        {
            var cart = _context.Carts.Include("Items").Where(c => c.Id == CartId && c.IsActive == true).FirstOrDefault();
            return cart;
        }

        public CartViewModel GetCartDetails(Guid CartId)
        {
            var cartViewModel = (from cartfromdb in _context.Carts where cartfromdb.Id == CartId && cartfromdb.IsActive == true select new CartViewModel
            {
                Id = cartfromdb.Id,
                UserId = cartfromdb.UserId,
                CreatedDate = cartfromdb.CreadtedDate,
                Items = (from cartItem in _context.CartItems join item in _context.Items on cartItem.ItemId equals item.Id where cartItem.CartId == CartId select new ItemViewModel
                {
                    Id = cartItem.Id,
                    Name = item.Title,
                    Description = item.Description,
                    ImageUrl = item.ImageUrl,
                    Quantity = cartItem.Quantity,
                    ItemId = item.Id,
                    UnitPrice = cartItem.UnitPrice
                }).ToList()
            }).FirstOrDefault();
            return cartViewModel;
        }
        public int UpdateCart(Guid CartId, int userId)
        {
            Cart carfromDb = GetCartById(CartId);
            carfromDb.UserId = userId;
            return _context.SaveChanges();
        }

        public int UpdateQty(Guid CartId, int itemId, int Quantity)
        {
            bool flag = false;
            var cartfromDb = GetCartById(CartId);
            if (cartfromDb != null)
            {
                for (int i = 0; i < cartfromDb.Items.Count; i++)
                {
                    if (cartfromDb.Items[i].Id == itemId)
                    {
                        flag = true;
                        if (Quantity > 0)
                            cartfromDb.Items[i].Quantity += (Quantity);
                        break;
                    }
                }
                if (flag)
                    return _context.SaveChanges();
            }
            return 0;
        }
    }
}
