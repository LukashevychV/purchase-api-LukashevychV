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
                sum += item.Price*item.Quantity;
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

        public bool Charge(decimal total, Card card)
        {
            if (card.ValidTo > DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
