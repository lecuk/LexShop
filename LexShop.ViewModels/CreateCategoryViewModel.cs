namespace LexShop.ViewModels
{
	public class CreateCategoryViewModel : ViewModelBase
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int ParentCategoryId { get; set; }
	}
}
