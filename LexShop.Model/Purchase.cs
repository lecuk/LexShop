using System;
using System.Collections.Generic;

namespace LexShop.Model
{
	public class Purchase
	{
		public long Id { get; set; }

		public string Token { get; set; } //idk what's the purpose
		public DateTime DateOfPurchase { get; set; }
		public decimal Total { get; set; }
		
		public long BuyerId { get; set; }
		public User Buyer { get; set; }

		public IList<PurchaseItem> Items { get; set; }
	}
}
