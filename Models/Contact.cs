using System.ComponentModel.DataAnnotations;
using PhoneShop.Models.ValidationAttributes;

namespace PhoneShop.Models
{
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Tên là dữ liệu bắt buộc.")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "Họ là dữ liệu bắt buộc.")]
        public string LastName { get; set; } = default!;

        [DataType(DataType.Date)]
        [CustomBirthDate(ErrorMessage = "Ngày sinh nhỏ hơn hoặc bằng ngày hiện tại.")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Nhập sai định dạng email.")]
        public string Email { get; set; } = default!;
    }
}
