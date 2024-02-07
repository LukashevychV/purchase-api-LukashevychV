using PurchaseApi.Models;

namespace PurchaseApi.Services
{
    public class PaymentService : IPaymentService
    {
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
