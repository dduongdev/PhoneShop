using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneShop.Models;
using PhoneShop.Services;

namespace PhoneShop.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private ProductService _productService;
        private IWebHostEnvironment _environment;
        public Product Product { get; set; } = default!;
        public List<string> ProductImages { get; set; } = default!;

        public DetailsModel(ProductService productService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _environment = environment;
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

            if (Product.ImagesUrl != null)
            {
			    var imagesPath = Path.Combine(Constants.BaseImagePath, Constants.ProductImagePath, Product.ImagesUrl);

			    ProductImages = Directory.GetFiles(Path.Combine(_environment.WebRootPath, imagesPath), "*.*")
                                        .Select(file => Path.Combine("\\", imagesPath, Path.GetFileName(file))).ToList();
            }

            return Page();
        }
    }
}
