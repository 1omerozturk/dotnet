using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers{


        

        [Area("Admin")]
    public class CategoryController:Controller{
    private readonly IServicesManager _manager;

        public CategoryController(IServicesManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index(){
            var model =_manager.CategoryService.GetAllCategories(false);
            return View(model);
        }
        public IActionResult Create(){
            return View();
        }
    }
}