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

        public IViewComponentResult Invoke(string page="default")
        {
            var products = _manager.ProductService.GetShowcaseProducts(false);
            return page.Equals("default")
                ?  View(products)
                :  View("List",products);
        }
    }
}