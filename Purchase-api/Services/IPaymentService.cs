using PurchaseApi.Models;

namespace PurchaseApi.Services
{
    public interface IPaymentService
    {
        bool Charge(decimal total, Card card);
    }
}
