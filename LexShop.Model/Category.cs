using System.Collections.Generic;

namespace LexShop.Model
{
	public class Category
	{
		public long Id { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public string HeaderImageName { get; set; }

		public long? ParentCategoryId { get; set; }
		public Category ParentCategory { get; set; }
		public IEnumerable<Category> ChildCategories { get; set; }
	}
}
