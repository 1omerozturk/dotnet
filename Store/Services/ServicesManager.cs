using Services.Contracts;
namespace Services
{

    public class ServicesManager : IServicesManager
    {
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        private readonly IOrderService _orderService;
        private readonly IAuthService _authService;


        public ServicesManager(IProductService productService
        , ICategoryService categoryServices,
IOrderService orderService,
IAuthService authService)
        {
            _productService = productService;
            _categoryService = categoryServices;
            _orderService = orderService;
            _authService = authService;
        }
        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;

        public IAuthService AuthService => _authService;

    }


}