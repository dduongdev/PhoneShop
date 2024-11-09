using System.ComponentModel;

namespace PhoneShop.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Mô tả sản phẩm")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("Giá sản phẩm")]
        public decimal Price { get; set; }
    }
}
