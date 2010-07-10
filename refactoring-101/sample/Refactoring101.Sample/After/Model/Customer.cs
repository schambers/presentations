using System.Collections.Generic;

namespace Refactoring101.Sample.After
{
	public class Customer
	{
		public IEnumerable<Video> RentedVideos { get; set; }
	}
}