using CharityEvents.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data.Cart
{
    public class ShoppingCart
    {
        //class used to add and remove data to a shopping cart
        public AppDbContext _context { get; set; }

        public String ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)        //static bc i use it in startup.cs file
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; //if is not null get the session by using the service provider
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();//if this is null generate a new cart id
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Band band)//band bc is the only thing that i can buy
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(m => m.Band.Id == band.Id && m.ShoppingCartId == ShoppingCartId); //check if i have that band in the cart 

            if (shoppingCartItem == null) //if the cart is empty
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Band = band,
                    Amount = 1//bc is the first item of that type
                };
                _context.ShoppingCartItems.Add(shoppingCartItem); //add the cart to db
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Band band)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(m => m.Band.Id == band.Id && m.ShoppingCartId == ShoppingCartId); //check if i have that band in the cart 

            if (shoppingCartItem != null) //if the cart is not empty
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);//remove the last item form 
                }
            }
            _context.SaveChanges();
        }


        //get all shoppingcart items
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(m => m.ShoppingCartId == ShoppingCartId).Include(m => m.Band).ToList());
        }

        //shoppingcart total
        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(m => m.ShoppingCartId == ShoppingCartId).Select(m => m.Band.DonationPrice * m.Amount).Sum();
            return total;
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(m => m.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items); //remove all the items
            await _context.SaveChangesAsync();
        }
    }
}
