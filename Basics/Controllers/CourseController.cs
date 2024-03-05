
using Basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers{

    public class CourseController:Controller{
        public IActionResult Index(){
            var model=Repository.Applications;
            return View(model);
        }

        [HttpGet]
        public IActionResult Apply(){
            return View();
        }

    [HttpPost]
    [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm]Candidate model){
            Repository.Add(model);
            return View("feedback",model);
        }
    }
    
    }
