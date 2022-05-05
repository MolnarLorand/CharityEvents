using CharityEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data.Services
{
    public interface IOrdersService
    {
        //add orders to db
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdress);

        //get all orders from db
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
