
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IServicesManager _manager;


        public ProductSummaryViewComponent(IServicesManager manager)
        {
            _manager = manager;
        }
        public string Invoke()
        {
            // ProductService.GetAllProducts(false) null döndürebilirse kontrol edin
            var products = _manager.ProductService.GetAllProducts(false);
            if (products == null || products.Count()==0)
            {
                // Ürün bulunamadı mesajı döndürün
                return "";
            }

            // Ürün sayısını döndürün
            return products.Count().ToString();
        }

    }
}