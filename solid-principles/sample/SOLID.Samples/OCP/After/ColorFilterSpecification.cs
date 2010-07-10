using System.Collections.Generic;

namespace SOLID.Samples.Tests.OCP.After
{
	public class ColorFilterSpecification : FilterSpecification
	{
		public ColorFilterSpecification(Color color)
		{
			Color = color;
		}

		public Color Color { get; private set; }

		public override IEnumerable<Product> Filter(IEnumerable<Product> products)
		{
			foreach (var product in products)
				if (product.Color == Color)
					yield return product;
		}
	}
}