using Services.Contracts;
namespace Services
{

    public class ServicesManager : IServicesManager
    {
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        private readonly IOrderService _orderService;

        public ServicesManager(IProductService productService
        , ICategoryService categoryServices,
IOrderService orderService)
        {
            _productService = productService;
            _categoryService = categoryServices;
            _orderService = orderService;
        }
        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;
    }


}