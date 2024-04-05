using Entities.Models;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtensions
    {
        // boş yani ilk açılan sayfada tüm ürünleri gösterme aksi takdirde bir categoryId varsa ona ait olan ürünleri geri döndüren kod bloğu tanımlandı.
        public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products, int? categoryID)
        {
            if (categoryID is null)
            {
                return products;
            }
            else
            {
                return products.Where(prd => prd.CategoryId.Equals(categoryID));
            }
        }
        public static IQueryable<Product> FilterBySearchTerm(this IQueryable<Product> products,
            String? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;
            else
            {
                return products.Where(prd => prd.ProductName.ToLower()
                  .Contains(searchTerm.ToLower())
                  );
            }
        }
        public static IQueryable<Product> FilterByPrice(this IQueryable<Product> products, int minPrice, int maxPrice, bool isValidPrice)
        {
            if (isValidPrice)
                return products.Where(
                    prd =>
                    prd.Price >= minPrice && prd.Price <= maxPrice);
            else
            {
                return products;
            }
        }

        public static IQueryable<Product> ToPaginate(this IQueryable<Product> products,
        int pageNumber, int pageSize)
        {
            return products
            .Skip(((pageNumber - 1) * pageSize))
            .Take(pageSize);
        }
    }
}