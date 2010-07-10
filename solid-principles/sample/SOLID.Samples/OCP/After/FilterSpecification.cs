using System.Collections.Generic;

namespace SOLID.Samples.Tests.OCP.After
{
	public abstract class FilterSpecification
	{
		public abstract IEnumerable<Product> Filter(IEnumerable<Product> products);
	}
}