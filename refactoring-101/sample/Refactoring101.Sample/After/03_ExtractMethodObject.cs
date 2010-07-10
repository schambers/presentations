using System.Collections.Generic;

namespace Refactoring101.Sample.After
{
	//
	// Dependency breaking technique
	//

	public class Order
	{
		// other methods and fields that deal with an Order

		public decimal CalculatePrice(Person customer,
			double taxAmount,
			IEnumerable<Item> items,
			IEnumerable<Discount> discounts,
			params decimal[] basePrices)
		{
			return new OrderCalculator(customer, taxAmount, items, discounts, basePrices)
				.Calculate();
		}
	}

	// Now OrderCalculator has to deal with internals of collaborating classes, not Order class
	// this class has now become your point of change
	public class OrderCalculator
	{
		public Person Customer { get; set; }
		public double TaxAmount { get; set; }
		public IEnumerable<Item> Items { get; set; }
		public IEnumerable<Discount> Discounts { get; set; }
		public decimal[] BasePrices { get; set; }

		public OrderCalculator(Person customer,
			double taxAmount,
			IEnumerable<Item> items,
			IEnumerable<Discount> discounts,
			params decimal[] basePrices)
		{
			Customer = customer;
			TaxAmount = taxAmount;
			Items = items;
			Discounts = discounts;
			BasePrices = basePrices;
		}

		public decimal Calculate()
		{
			decimal total = CalculateItemsTotal();

			total = CalculateDiscount(total);

			total = DeductCountryDiscount(total);

			total = DeductBasePrices(total);

			return total;
		}

		private decimal CalculateItemsTotal()
		{
			decimal total = 0m;
			foreach (Item item in Items)
			{
				total += item.Amount;
			}

			return total;
		}

		private decimal CalculateDiscount(decimal total)
		{
			foreach (Discount discount in Discounts)
			{
				total -= discount.Amount;
			}
			return total;
		}

		private decimal DeductCountryDiscount(decimal total)
		{
			if (Customer.Country == Country.UnitedKingdom)
				total -= 10m;
			return total;
		}

		private decimal DeductBasePrices(decimal total)
		{
			foreach (decimal basePrice in BasePrices)
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
