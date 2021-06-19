using System;

namespace LexShop.ViewModels
{
	public class ErrorViewModel : ViewModelBase
	{
		public string RequestId { get; set; }
		public bool ShowRequestId => !String.IsNullOrEmpty(RequestId);
	}
}
