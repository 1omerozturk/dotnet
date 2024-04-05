
using Glcyzn.Web.Models;

namespace Glcyzn.Models
{
    public class ProductRepository{
        private static readonly List<Product>? _products;


        public List<Product>Products()=>_products;
        public void Add(Product newProduct)=>_products.Add(newProduct);
        public void Remove(int id){
            var hasProduct=_products.FirstOrDefault(x=>x.Id==id);
            if(hasProduct==null){
                throw new Exception($"Bu id(${id})'ye sahip bir ürün bulunamadı");
        }
        else{
        _products.Remove(hasProduct);
        }
        }

        public void Update(Product updateProduct){
            var hasProduct=_products.FirstOrDefault(x=>x.Id==updateProduct.Id);
            if(hasProduct==null){
                throw new Exception($"Bu id(${updateProduct.Id})'ye sahip bir ürün bulunamadı");
        }
        else{
       hasProduct.ProductName=updateProduct.ProductName;
       hasProduct.Price=updateProduct.Price;
       hasProduct.Stock=updateProduct.Stock;
       var index=_products.FindIndex(x=>x.Id==updateProduct.Id);
       _products[index]=hasProduct;
        }
        }

        }
}