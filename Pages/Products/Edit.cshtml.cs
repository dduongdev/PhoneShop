using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneShop.Models;
using PhoneShop.Services;

namespace PhoneShop.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ProductService _productService;

        public EditModel(ProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            Product = product;
            return Page();
        }

        public IActionResult OnPost()
        {
            var existingProduct = _productService.GetById(Product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.Update(Product);
            return RedirectToPage("Index");
        }
    }
}
