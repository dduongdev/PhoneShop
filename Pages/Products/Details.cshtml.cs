using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneShop.Models;
using PhoneShop.Services;

namespace PhoneShop.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private ProductService _productService;
        public Product Product { get; set; } = default!;

        public DetailsModel(ProductService productService)
        {
            _productService = productService;
        }


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
    }
}
