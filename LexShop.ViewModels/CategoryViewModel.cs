using LexShop.Model;
using System.Collections.Generic;

namespace LexShop.ViewModels
{
	public class CategoryViewModel : ViewModelBase
	{
		public Category Category { get; set; }

		public IEnumerable<Category> AncestorCategories { get; set; }
		public IEnumerable<Product> Products { get; set; }
	}
}
