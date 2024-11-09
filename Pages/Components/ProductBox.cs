using Microsoft.AspNetCore.Mvc;
using PhoneShop.Models;
using PhoneShop.Services;

namespace RazorPageSample1.Pages.Components.ProductBox
{
	public class ProductBox : ViewComponent
	{
		private ProductService _productService;

		public ProductBox(ProductService productService)
		{
			_productService = productService;
		}

		//public IViewComponentResult Invoke()
		//{
		//	return View<List<Product>>(products);
		//}

		public async Task<IViewComponentResult> InvokeAsync(bool sapxeptrang = true)
		{
			List<Product> _products = null;
			if (sapxeptrang)
			{
				_products = _productService.GetAll().OrderBy(p => p.Price).ToList();
			}
			else
			{
				_products = _productService.GetAll().OrderByDescending(p => p.Price).ToList();
			}
			return View<List<Product>>(_products);
		}
	}
}