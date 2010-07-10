using System;
using NUnit.Framework;
using SOLID.Samples.ISP.Before;
using SpecUnit;

namespace SOLID.Samples.Tests.ISP.Before
{
	[Concern("ISP"), TestFixture]
	public class when_grooming_and_feeding_pets : ContextSpecification
	{
		[Observation, Test]
		public void can_feed_a_dog()
		{
			IAnimal dog = new Dog();
			dog.Feed().ShouldEqual("dog fed");
		}

		[Observation, Test]
		public void can_feed_a_snake()
		{
			IAnimal ant = new Ant();
			ant.Feed().ShouldEqual("ant fed");
		}

		[Observation, Test]
		public void can_groom_a_dog()
		{
			IAnimal dog = new Dog();
			dog.Groom().ShouldEqual("dog groomed");
		}

		[Observation, Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void cannot_groom_a_snake()
		{
			IAnimal snake = new Ant();
			snake.Groom();
		}
	}
}
