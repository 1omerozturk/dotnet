using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos
{
    public record ProductDto
    {
        // set yerine init kullanılmasının sebebi sadece nesne ilk oluşturulduğunda kullanılır ve ardından asla değiştirilemez. Ama set kullanılırsa istenildiğinde değiştirilebilir olurdu.
        public int ProductId { get; init; }
        [Required(ErrorMessage = "Product Name is required.")]
        public String? ProductName { get; init; } = String.Empty;
        [Required(ErrorMessage = "Product Price is required.")]
        public decimal Price { get; init; }
        public String? Summary { get; init; } = String.Empty;
        public String? ImageUrl { get; set; }
        public int? CategoryId { get; init; } //Foreign key
        public Category? Category { get; init; }
    }
}