using PurchaseApi.Models;

namespace PurchaseApi.Services
{
    public class PaymentService : IPaymentService
    {
        bool IPaymentService.Charge(decimal total, Card card)
        {
            if (card.ValidTo > DateTime.Now) 
            {
                return false;
            }
            return true;
        }
    }
}
