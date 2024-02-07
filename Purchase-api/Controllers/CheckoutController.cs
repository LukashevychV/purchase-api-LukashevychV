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
            decimal totalsum = _cartService.TotalSum(cart.items);
            bool paymentSuccessful = _paymentService.Charge(totalsum, cart.card);

            if (paymentSuccessful)
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