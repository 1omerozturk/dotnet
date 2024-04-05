
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategorySummaryViewComponent : ViewComponent
    {
        private readonly IServicesManager _manager;


        public CategorySummaryViewComponent(IServicesManager manager)
        {
            _manager = manager;
        }
        public string Invoke()
        {
            // ProductService.GetAllProducts(false) null döndürebilirse kontrol edin
            var categories = _manager.CategoryService.GetAllCategories(false);
            if (categories == null || categories.Count()==0)
            {
                // Ürün bulunamadı mesajı döndürün
                return "";
            }

            // Ürün sayısını döndürün
            return categories.Count().ToString();
        }

    }
}