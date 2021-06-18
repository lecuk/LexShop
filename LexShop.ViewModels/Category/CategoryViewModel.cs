using System;
using System.Collections.Generic;
using System.Text;

namespace LexShop.ViewModels.Category
{
	public class CategoryViewModel : ViewModelBase
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ParentCategoryId { get; set; }
		public string ParentCategoryName { get; set; }
		public IEnumerable<string> ParentCategories { get; set; }
	}
}
