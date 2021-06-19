using LexShop.Model;
using System.Threading.Tasks;

namespace LexShop.Services
{
	public interface ILuckyService
	{
		Product GetRandomProduct();
		Task<Product> GetRandomProductAsync();
	}
}
