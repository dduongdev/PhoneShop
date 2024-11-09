namespace PhoneShop.Models.DataFetchStrategies
{
	public class DemoDataFetchStrategy : IDataFetchStrategy
	{
		public async Task<IEnumerable<Product>> FetchDataAsync()
		{
			var products = new List<Product>()
			{
				new Product()
					{
						Name = "Iphone 14 Pro",
						Description = "Apple",
						Price = 1400
					},
				new Product()
					{
						Name = "Samsung Galaxy S24 Ultra",
						Description = "Samsung",
						Price = 2899
					},
				new Product()
					{
						Name = "Sony Xperia",
						Description = "Sony",
						Price = 799
					}
			};
			return await Task.FromResult(products);
		}
	}
}
