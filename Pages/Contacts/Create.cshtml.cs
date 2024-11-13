using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneShop.Models;

namespace PhoneShop.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; } = default!;

        public void OnGet()
        {
        }

        public string Message { get; set; } = default!;

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Dữ liệu gửi đến hợp lệ";
            }
            else
            {
                Message = "Dữ liệu không hợp lệ";
            }
        }
    }
}
