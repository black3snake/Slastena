using Microsoft.AspNetCore.Mvc;
using Slastena.Models;

namespace Slastena.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }


        public IActionResult Checkout() //GET
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var item = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = item;
            
            if(_shoppingCart.ShoppingCartItems.Count == 0) 
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            
            return View(order);
        }


        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for you order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
