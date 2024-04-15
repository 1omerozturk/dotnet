using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
     [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IServicesManager _manager;

        public ProductController(IServicesManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index([FromQuery] ProductRequestParameters p)
        {
            var model = _manager.ProductService.GetAllProductsWithDetails(p);
            var pagination=new Pagination(){
                CurrentPage=p.PageNumber,
                ItemsPerPage=p.PageSize,
                TotalItmes=_manager.ProductService.GetAllProducts(false).Count()
            };

            return View(new ProductListViewModel(){
                Products=model,
                Pagination=pagination
            });
        }
        public IActionResult Get(int id){
            var model=_manager.ProductService.GetOneProduct(id,false);
            return View(model);

        }
         private SelectList GetCategoriesSelectList(){
            return new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName", "1");
        }

        public IActionResult Create()
        {
            // select option yapısında foreach den kurtulmak için bu şekilde aynı mantık kullanılabilir.
            // ------------------------------------
            // ViewBag.Categories=_manager.CategoryService.GetAllCategories(false);

            //yani bu yapı yerine 
            /*
            <select  class="form-control">
            @foreach(Category cat in ViewBag.Categories){
                <option value="@cat.CategoryId">
                    @cat.CategoryName
                </option>
            }
        </select>
            */
            // Bu yapı kullanılacaktır. Ve Tek satıra düşecek işlemlerimiz.
            /*
            <select class="form-control" asp-items="@ViewBag.Categories" asp-for="CategoryId" 

             */

            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                // file operations
                string path=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);

                using(var stream =new FileStream(path,FileMode.Create)){
                        await file.CopyToAsync(stream);
                }
                productDto.ImageUrl=String.Concat("/images/",file.FileName);
                _manager.ProductService.CreateProduct(productDto);

                return RedirectToAction("Index");
            }
            return View();
        }
       
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProductForUpdate(id, false);
               ViewBag.Categories =GetCategoriesSelectList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                // file operations
                string path=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);

                using(var stream =new FileStream(path,FileMode.Create)){
                        await file.CopyToAsync(stream);
                }
                productDto.ImageUrl=String.Concat("/images/",file.FileName);

                _manager.ProductService.UpdateOneProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }



    }
}