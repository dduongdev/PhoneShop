using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; } = default!;

        [DisplayName("Mô tả sản phẩm")]
        public string? Description { get; set; } 

		[Required(ErrorMessage = "Giá sản phẩm là bắt buộc.")]
		[DisplayName("Giá sản phẩm")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Giá sản phẩm phải là một số dương.")]
        public decimal Price { get; set; }
        public string? ImagesUrl { get; set; }
    }
}
