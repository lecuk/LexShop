using System;
using System.Collections.Generic;
using System.Text;

namespace LexShop.Model
{
	public class Category
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Category ParentCategory { get; set; }
	}
}
