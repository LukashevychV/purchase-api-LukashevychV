using PurchaseApi.Models;

namespace PurchaseApi.Services
{
    public interface ICartService
    {
        decimal TotalSum(IEnumerable<CartItem> items);
        int TotalQuantity(IEnumerable<CartItem> items);
    }
}
