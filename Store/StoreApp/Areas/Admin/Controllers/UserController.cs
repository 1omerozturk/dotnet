using Microsoft.AspNetCore.Mvc;
using Services;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ServicesManager _manager;

        public UserController(ServicesManager manager)
        {
            _manager=manager;
        }
        public IActionResult Index()
        {
            var users=_manager.AuthService.GetAllUsers();
            return View(users);
        }
    }
}