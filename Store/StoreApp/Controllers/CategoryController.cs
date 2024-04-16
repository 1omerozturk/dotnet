using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repositories.Contracts;
namespace StoreApp.Controllers
{

    public class CategoryController : Controller
    {
        private IRepositoryManager _manager;

        public CategoryController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model=_manager.Category.FindAll(false);
             ViewData["Title"]="Categories";
            return View(model);
        }
    }
}