using Microsoft.AspNetCore.Mvc;

namespace PurchaseApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // your code here
        }

        [HttpGet("{index}")]
        public string Get(int index)
        {
            // your code here
        }

        [HttpPost]
        public string Create([FromBody] string name)
        {
            // your code here
        }

        [HttpPut("{index}")]
        public string Update(int index, string name)
        {
            // your code here
        }

        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            // your code here
        }
    }
}