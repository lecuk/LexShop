namespace LexShop.Model
{
	public class PurchaseItem
	{
		public long Id { get; set; }

		public long ProductId { get; set; }
		public Product Product { get; set; }

		public long PurchaseId { get; set; }
		public Purchase Purchase { get; set; }

		public decimal Quantity { get; set; }
	}
}
