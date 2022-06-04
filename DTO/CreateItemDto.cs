using System.ComponentModel.DataAnnotations;

namespace Catalog.Dto {
    // các trường dữ liệu sẽ nhập vào bằng phương thức POST
    public record CreateItemDto{
        [Required]
          public string Name {get;init;}
            [Required]
            
            public decimal Price { get; init; }
    }
}