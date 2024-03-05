using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class EmployeeController:Controller{
        public ViewResult Index2(){
            return View("Index2");
        }
    }

}