using System.Collections.Generic;

namespace LexShop.Model
{
	public class User
	{
		public long Id { get; set; }
		
		public string FirstName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string City { get; set; }

		public IList<PaymentMethod> PaymentMethods { get; set; }
		
		public UserAuth Auth { get; set; }
	}
}
