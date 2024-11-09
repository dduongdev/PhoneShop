using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneShop.Models;
using PhoneShop.Services;

namespace PhoneShop.Pages.Products
{
    public class DeleteModel : PageModel
    {
		private readonly ProductService _productService;

		public DeleteModel(ProductService productService)
		{
			_productService = productService;
		}

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

		public IActionResult OnPost(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			_productService.Delete(id.Value);
			return RedirectToPage("Index");
		}
	}
}
