using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
      [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServicesManager _manager;

        public ProductsController(IServicesManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllProducts(){
            return Ok(_manager.ProductService.GetAllProducts(false));
        }
    }
}