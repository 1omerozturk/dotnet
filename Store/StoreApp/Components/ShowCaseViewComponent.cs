using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ShowCaseViewComponent : ViewComponent
    {
        private readonly IServicesManager _manager;

        public ShowCaseViewComponent(IServicesManager manager)
        {
            _manager = manager;

        }

        public IViewComponentResult Invoke()
        {
            var products=_manager.ProductService.GetShowCaseProducts(false);
            return View(products);
        }
    }
}