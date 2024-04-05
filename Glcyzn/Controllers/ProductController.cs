using Glcyzn.Models;
using Glcyzn.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Glcyzn.Controllers{

public class ProductController:Controller{

public IActionResult Index(){
    var productList=new List<Product>(){
        new(){Id=1,ProductName="Kalem",Price=100,Stock=9},
        new(){Id=2,ProductName="Defter",Price=300,Stock=4},
        new(){Id=3,ProductName="Silgi",Price=200,Stock=5},
        new(){Id=4,ProductName="Çanta",Price=500,Stock=8}
    };
    return View(productList);
}
public static void Remove(int id){
    var prd=new ProductRepository();
    prd.Remove(id);
}
}

}