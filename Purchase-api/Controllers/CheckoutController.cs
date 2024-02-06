using Microsoft.AspNetCore.Mvc;
using PurchaseApi.Models;

namespace PurchaseApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        [HttpPost]
        public string ConductCheckout(Cart cart)
        {
            // your code here
        }
    }
}