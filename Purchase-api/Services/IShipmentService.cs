using PurchaseApi.Models;
namespace PurchaseApi.Services
{
    public interface IShipmentService
    {
        string Ship(AddressInfo info, IEnumerable<CartItem> items);
    }
}
