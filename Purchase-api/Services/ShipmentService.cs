using PurchaseApi.Models;

namespace PurchaseApi.Services
{
    public class ShipmentService : CartService, IShipmentService
    {
        private readonly ICartService _cartService;
        public ShipmentService(ICartService cartService)
        { 
            _cartService = cartService;
        }

        string IShipmentService.Ship(AddressInfo info, IEnumerable<CartItem> items)
        {
            return $"{info.City} on total sum {_cartService.TotalSum(items)}";
        }
    }
}
