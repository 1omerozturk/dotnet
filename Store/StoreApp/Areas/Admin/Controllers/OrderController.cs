using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
     [Authorize(Roles = "Admin")]
    public class OrderController:Controller{
        private readonly IServicesManager _manager;

        public OrderController(IServicesManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index(){
            var orders=_manager.OrderService.Orders;
            return View(orders);
        }
        [HttpPost]
        public IActionResult Complete([FromForm] int id){
            _manager.OrderService.Complete(id);
            return RedirectToAction("Index");
        }
    }
}