using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FluentAssertions;
using ImmoCalc.Domain;
using ImmoCalc.Stores.Infos;
using ImmoCalc.Tests.Assets;
using TechTalk.SpecFlow;

namespace ImmoCalc.Tests.Steps {
	[Binding]
	public sealed class ComputedDataSteps 
	{
		private readonly ComputedDataContext _context;

		public ComputedDataSteps(ComputedDataContext context)
		{
			_context = context;
		}

		[When(@"I set the buying price to (.*)")]
		public void WhenISetTheBuyingPriceTo(double price)
		{
			_context.Reducer.Handle(new InfosState.ChangeValue(BuyingPrice.From(price)), CancellationToken.None);
		}

		[Then(@"the buying price value is (.*)")]
		public void ThenTheBuyingPriceValueIs(double value)
		{
			_context.State.BuyingPrice.Value.Should().Be(value);
		}

		[Then(@"the notary fees value is (.*)")]
		public void ThenTheNotaryFeesValueIs(double value)
		{
			_context.State.NotaryFees.Value.Should().Be(value);
		}

	}
}
