using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhoneShop.Models;
using PhoneShop.Models.DataFetchStrategies;
using PhoneShop.Services;

namespace PhoneShop.Pages.Products
{
    public class IndexModel : PageModel
    {
        private ProductService _productService;

        public IList<Product> Products { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public IndexModel(ProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Danh sách sản phẩm";

            if (!string.IsNullOrEmpty(SearchString))
            {
                Products = _productService.GetAll().Where(p => p.Name.Contains(SearchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                Products = _productService.GetAll();
            }
        }

        public IActionResult OnGetRemoveAll()
        {
            _productService.Truncate();
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnGetLoadAll()
        {
            await _productService.FetchData();
            return RedirectToPage("Index");
        }
    }
}
