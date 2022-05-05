using CharityEvents.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data.Services
{
    public class OrdersService : IOrdersService
    {
        //i work with the db so i need to inject appdbcontext
        private readonly AppDbContext _context;
        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(m => m.OrderItems).ThenInclude(m => m.Band).Include(m=> m.User).ToListAsync(); //all orders in the app

            if(userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdress)
        {
            var order = new Order()
            {
                //id is generated in the db
                UserId = userId,
                Email = userEmailAdress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            //after i add and save -> i have the new orderId, store all the shoppingcartitems in db
            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    BandId = item.Band.Id,
                    OrderId = order.Id, //up
                    Price = item.Band.DonationPrice
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();

        }
    }
}
