using System;
using System.Collections.Generic;
using System.Text;

namespace LexShop.Model
{
	public class Purchase
	{
		public long Id { get; set; }
		public Product Product { get; set; }
		public decimal Quantity { get; set; }
		public Person Buyer { get; set; }
		public DateTime DateOfPurchase { get; set; }
		public string Token { get; set; } //idk what's the purpose
	}
}
