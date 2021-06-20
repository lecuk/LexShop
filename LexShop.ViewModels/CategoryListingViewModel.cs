using LexShop.Model;
using System.Collections.Generic;

namespace LexShop.ViewModels
{
	public class CategoryListingViewModel : ViewModelBase
	{
		public IEnumerable<Category> RootCategories { get; set; }
	}
}
