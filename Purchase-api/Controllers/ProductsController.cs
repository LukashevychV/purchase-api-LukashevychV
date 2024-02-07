using Microsoft.AspNetCore.Mvc;
using PurchaseApi.Services;

namespace PurchaseApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IDataProviderService _providerService;

        public ProductsController(IDataProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
             return _providerService.GetProducts();
        }

        [HttpGet("{index}")]
        public string Get(int index)
        {
            return _providerService.GetProduct(index);
        }

        [HttpPost]
        public string Create([FromBody] string name)
        {
            return _providerService.CreateProduct(name);
        }

        [HttpPut("{index}")]
        public string Update(int index, string name)
        {
            return _providerService.UpdateProduct(index, name);
        }

        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            _providerService?.DeleteProduct(index);
        }
    }
}