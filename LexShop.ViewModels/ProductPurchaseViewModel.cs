using System;
using System.Collections.Generic;
using System.Text;

namespace LexShop.ViewModels
{
	public class ProductPurchaseViewModel : ViewModelBase
	{
		public long ProductId { get; set; }
		public decimal Quantity { get; set; }
	}
}
