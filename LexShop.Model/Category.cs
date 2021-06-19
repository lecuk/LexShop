using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LexShop.Model
{
	public class Category
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual long? ParentCategoryId { get; set; }
		public virtual Category ParentCategory { get; set; }
		public virtual IEnumerable<Category> ChildCategories { get; set; }

		public string HeaderImageName { get; set; }
	}
}
