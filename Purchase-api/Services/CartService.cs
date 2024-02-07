using PurchaseApi.Models;

namespace PurchaseApi.Services
{
    public class CartService : ICartService
    {
        public decimal TotalSum(IEnumerable<CartItem> items)
        {
            decimal sum = 0;

            foreach (var item in items)
            {
                sum += item.Price;
            }

            return sum;
        }

        public int TotalQuantity(IEnumerable<CartItem> items)
        {
            int totalQuantity = 0;

            foreach (var item in items)
            {
                totalQuantity += item.Quantity;
            }

            return totalQuantity;
        }

        public bool Charge(decimal totalPrice, Card card)
        {
            throw new NotImplementedException();
        }
    }
}
