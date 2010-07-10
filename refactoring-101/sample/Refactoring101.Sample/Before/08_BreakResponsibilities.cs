using System.Collections.Generic;
using System.Linq;

namespace Refactoring101.Sample.Before
{
	public class VideoStoreService
	{
		public Customer SignupCustomer(string name, string address)
		{
			// Set customer attributes

			return new Customer();
		}

		public void RentVideo(Video video)
		{
			// rent video code
		}

		public void ReturnVideo(Video video)
		{
			// return video
		}

		public void PayLateFee(Customer customer, decimal feePaid)
		{
			// code to pay late fee
		}

		public bool CanRentVideo(Customer customer)
		{
			return customer.RentedVideos.Count() < 3;
		}
	}

	public class Video
	{
	}

	public class Customer
	{
		public IEnumerable<Video> RentedVideos { get; set; }
	}
}
