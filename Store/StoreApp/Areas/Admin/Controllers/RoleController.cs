using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController:Controller{
        private readonly IServicesManager _manager;

        public RoleController(IServicesManager servicesManager)
        {
            _manager = servicesManager;
        }
        public IActionResult Index(){
    
            return View(_manager.AuthService.Roles);
        }
    }
}