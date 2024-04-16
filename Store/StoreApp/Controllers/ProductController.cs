using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using StoreApp.Models;


namespace Store.StoreApp
{
    public class ProductController : Controller
    {
        private readonly IServicesManager _manager;

        public ProductController(IServicesManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
            var products = _manager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItmes = _manager.ProductService.GetAllProducts(false).Count(),
            };
            ViewData["Title"] = "Products";
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination

            });
        }
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            ViewData["Title"]=model?.ProductName;
            return View(model);
        }

    }
}