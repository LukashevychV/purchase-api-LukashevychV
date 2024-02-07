using Microsoft.AspNetCore.Mvc;
using PurchaseApi.Models;
using PurchaseApi.Services;

namespace PurchaseApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;
        private readonly IShipmentService _shipmentService;

        public CheckoutController(ICartService cartService, IPaymentService paymentService, IShipmentService shipmentService)
        {
            _cartService = cartService;
            _paymentService = paymentService;
            _shipmentService = shipmentService;
        }

        [HttpPost]
        [Route("/Checkout")]
        public string ConductCheckout(Cart cart)
        {
            if (_cartService.Charge(_cartService.TotalSum(cart.items), cart.card))
            {
                return _shipmentService.Ship(cart.addressInfo, cart.items);
            }
            else
            {
                return "not charged";
            }
        }
    }
}