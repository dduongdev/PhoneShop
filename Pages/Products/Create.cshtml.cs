using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneShop.Models;
using PhoneShop.Services;
using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ProductService _productService;
		private readonly IWebHostEnvironment _environment;

		public CreateModel(ProductService productService, IWebHostEnvironment environment)
		{
			_productService = productService;
			_environment = environment;
		}

		[BindProperty]
        public Product Product { get; set; } = default!;

        [Required(ErrorMessage = "Cần upload ít nhất một ảnh.")]
        [DataType(DataType.Upload)]
        //[FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [BindProperty]
        public List<IFormFile> ProductImages { get; set; } = default!;

		public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            Product.ImagesUrl = $"{Product.Id}_images";
            _productService.Add(Product);

            var imagesPath = Path.Combine(_environment.WebRootPath, Constants.BaseImagePath, Constants.ProductImagePath, Product.ImagesUrl);

            Directory.CreateDirectory(imagesPath);

            for (int i = 0; i < ProductImages.Count; i++)
            {
                var imageFilePath = Path.Combine(imagesPath, ProductImages[i].FileName);

                using (var fileStream = new FileStream(imageFilePath, FileMode.Create))
                {
                    await ProductImages[i].CopyToAsync(fileStream);
                }
            }

            return RedirectToPage("Index");
        }
    }
}
