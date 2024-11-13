using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Models.ValidationAttributes
{
    public class CustomBirthDate : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime? dateOfBirth = (DateTime?)value;
            return (dateOfBirth <= DateTime.Now) ? true : false;
        }
    }
}
