using System.Collections.Generic;

namespace Refactoring101.Sample.Before
{
	// Dependency breaking technique

	public class Order
	{
		// other methods and fields that deal with an Order

		public decimal CalculatePrice(Person customer,
			double taxAmount,
			IEnumerable<Item> items,
			IEnumerable<Discount> discounts,
			params decimal[] basePrices)
		{
			decimal total = 0m;

			foreach (Item item in items)
			{
				total += item.Amount;
			}

			foreach (Discount discount in discounts)
			{
				total -= discount.Amount;
			}

			if (customer.Country == Country.UnitedKingdom)
				total -= 10m; // VAT

			foreach (decimal basePrice in basePrices)
			{
				if (basePrice > total)
				{
					total -= basePrice;
				}
			}

			return total;
		}
	}

	public class Person
	{
		public Country Country { get { return Country.UnitedKingdom; } }
	}

	public enum Country
	{
		UnitedStates,
		UnitedKingdom
	}

	public class Discount
	{
		public decimal Amount { get; set; }
	}

	public class Item
	{
		public decimal Amount { get; set; }
	}
}
