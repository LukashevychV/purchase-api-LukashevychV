using PurchaseApi.Models;

namespace PurchaseApi.Services
{
    public interface ICartService : IPaymentService
    {
        decimal TotalSum(IEnumerable<CartItem> items);
        int TotalQuantity(IEnumerable<CartItem> items);
    }
}
