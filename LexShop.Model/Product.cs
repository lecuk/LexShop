using System;
using System.Collections.Generic;
using System.Text;

namespace LexShop.Model
{
	public class Product
	{
		public long Id { get; set; }
		public Category Category { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string IconName { get; set; }
		public Vendor Vendor { get; set; }
		public decimal BasePrice { get; set; }
	}
}
