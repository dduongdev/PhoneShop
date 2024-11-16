using PhoneShop.Models;
using PhoneShop.Models.DataFetchStrategies;

namespace PhoneShop.Services
{
	public class ProductService
	{
		private List<Product> _products;
		private IDataFetchStrategy _dataFetchStrategy;

		public ProductService(IDataFetchStrategy dataFetchStrategy)
		{
			_products = new List<Product>();
			_dataFetchStrategy = dataFetchStrategy;
		}

		public List<Product> GetAll() => _products;

		public Product? GetById(Guid id) => _products.FirstOrDefault(p => p.Id == id);

		public void Add(Product product) => _products.Add(product);

		public void Update(Product product)
		{
			var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
			if (existingProduct != null)
			{
				existingProduct.Name = product.Name;
				existingProduct.Description = product.Description;
				existingProduct.Price = product.Price;
			}
		}

		public void Delete(Guid id)
		{
			var product = _products.FirstOrDefault(p => p.Id == id);
			if (product != null)
			{
				_products.Remove(product);
			}
		}

		public void Truncate() => _products.Clear();

		public async Task FetchData()
		{
			_products.AddRange(await _dataFetchStrategy.FetchDataAsync());
		}
	}
}
