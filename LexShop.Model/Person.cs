using System;
using System.Collections.Generic;
using System.Text;

namespace LexShop.Model
{
	public class Person
	{
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public IList<PaymentMethod> PaymentMethods { get; set; }
	}
}
