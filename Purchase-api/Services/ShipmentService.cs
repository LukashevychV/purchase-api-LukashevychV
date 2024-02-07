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

        public string Ship(AddressInfo info, IEnumerable<CartItem> items)
        {
            return $"Shipped {_cartService.TotalQuantity(items)} items to  {info.City} on total sum {_cartService.TotalSum(items)}$";
        }
    }
}
