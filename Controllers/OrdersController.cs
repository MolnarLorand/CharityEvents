using CharityEvents.Data.Cart;
using CharityEvents.Data.Services;
using CharityEvents.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IBandsService _bandsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        public OrdersController(IBandsService bandsService, ShoppingCart shoppingCart, IOrdersService ordersService)//i inject the shopping cart & band service
        {
            _bandsService = bandsService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = "";
            //get all orders from db
            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var bandItem = await _bandsService.GetBandByIdAsync(id);

            if (bandItem != null)
            {
                _shoppingCart.AddItemToCart(bandItem);

            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var bandItem = await _bandsService.GetBandByIdAsync(id);

            if (bandItem != null)
            {
                _shoppingCart.RemoveItemFromCart(bandItem);

            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAdress = "";

            await _ordersService.StoreOrderAsync(items,userId,userEmailAdress);
            //after i store the order in db i will cleanup the cart
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
            
        }
    }
}
