using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneShop.Models;
using PhoneShop.Services;

namespace PhoneShop.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ProductService _productService;

        public CreateModel(ProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _productService.Add(Product);
            return RedirectToPage("Index");
        }
    }
}
