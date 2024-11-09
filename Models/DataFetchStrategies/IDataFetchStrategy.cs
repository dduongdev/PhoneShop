namespace PhoneShop.Models.DataFetchStrategies
{
	public interface IDataFetchStrategy
	{
		Task<IEnumerable<Product>> FetchDataAsync();
	}
}
