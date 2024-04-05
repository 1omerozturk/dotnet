using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages{
    public class DemoModel:PageModel{
        public String? FullName => HttpContext?.Session?.GetString("name")?? "Please to be Login" ;
        
        
        public void Onget(){

        }
        public void OnPost([FromForm]string name){
            HttpContext.Session.SetString("name",name);
        }
        public void Close(){
            HttpContext.Session.Remove("name");
        }
    }
}