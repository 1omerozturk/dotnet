using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig:IEntityTypeConfiguration<Product>{
        public void Configure(EntityTypeBuilder<Product> builder){
            builder.HasKey(p=>p.ProductId);
            builder.Property(p=>p.ProductName).IsRequired();
            builder.Property(p=>p.Price).IsRequired();

            builder.HasData(

                new Product() { ProductId = 1, CategoryId = 2, ImageUrl="images/1.jpg",ShowCase=false,  ProductName = "Computer", Price = 30_000 },
            new Product() { ProductId = 2, CategoryId = 2, ImageUrl="/images/2.jpg",ShowCase=false,  ProductName = "Phone", Price = 3_000 },
            new Product() { ProductId = 3, CategoryId = 2, ImageUrl="/images/3.jpg", ShowCase=false, ProductName = "Monitor", Price = 5_000 },
            new Product() { ProductId = 4, CategoryId = 2, ImageUrl="/images/4.jpg",ShowCase=false,  ProductName = "Mouse", Price = 1_000 },
            new Product() { ProductId = 5, CategoryId = 2, ImageUrl="/images/5.jpg",ShowCase=false,  ProductName = "Keyboard", Price = 1_500 },
            new Product() { ProductId = 6, CategoryId = 1, ImageUrl="/images/6.jpg",ShowCase=false,  ProductName = "History", Price = 250 },
            new Product() { ProductId = 7, CategoryId = 1, ImageUrl="/images/7.jpg",ShowCase=false,  ProductName = "Hamlet", Price = 150 },
            new Product() { ProductId = 8, CategoryId = 2, ImageUrl="/images/8.jpg",ShowCase=true,  ProductName = "XP-Pen", Price = 150 },
            new Product() { ProductId = 9, CategoryId = 2, ImageUrl="/images/9.jpg", ShowCase=true, ProductName = "Galaxy FE", Price = 150 },
            new Product() { ProductId = 10, CategoryId = 1, ImageUrl="/images/10.jpg",ShowCase=true,  ProductName = "HP Headset", Price = 150 }
            );
        }
    }
}