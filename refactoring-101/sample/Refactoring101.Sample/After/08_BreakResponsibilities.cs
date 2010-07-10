using System.Linq;

namespace Refactoring101.Sample.After
{
	public class VideoStoreService
	{
		public IStoreRegistration StoreRegistration { get; set; }
		public IVideoManagement VideoManagement { get; set; }
		public ICustomerAccount CustomerAccount { get; set; }

		public VideoStoreService(
			IStoreRegistration storeRegistration,
			IVideoManagement videoManagement,
			ICustomerAccount customerAccount)
		{
			StoreRegistration = storeRegistration;
			VideoManagement = videoManagement;
			CustomerAccount = customerAccount;
		}

		public Customer SignupCustomer(string name, string address)
		{
			return StoreRegistration.SignupCustomer(name, address);
		}

		public void RentVideo(Video video)
		{
			VideoManagement.RentVideo(video);
		}

		public void ReturnVideo(Video video)
		{
			VideoManagement.ReturnVideo(video);
		}

		public void PayLateFee(Customer customer, decimal feePaid)
		{
			CustomerAccount.PayLateFee(customer, feePaid);
		}

		public bool CanRentVideo(Customer customer)
		{
			return CustomerAccount.CanRentVideo(customer);
		}
	}

	public interface ICustomerAccount
	{
		void PayLateFee(Customer customer, decimal feePaid);
		bool CanRentVideo(Customer customer);
	}

	public interface IVideoManagement
	{
		void RentVideo(Video video);
		void ReturnVideo(Video video);
	}

	public interface IStoreRegistration
	{
		Customer SignupCustomer(string name, string address);
	}
}
