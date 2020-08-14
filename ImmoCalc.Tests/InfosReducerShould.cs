using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using FluentAssertions;
using ImmoCalc.Domain;
using ImmoCalc.Stores.Infos;
using ImmoCalc.Tests.Tools;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Xunit;

namespace ImmoCalc.Tests
{
	public class InfosReducerShould
	{
		[Fact]
		public void ChangeBuyingInformation()
		{
			var state = new InfosState();
			var reducer = new InfosReducer(new TestStore(state));
			reducer.Handle(new InfosState.ChangeBuyingPrice(BuyingPrice.From(100000)), CancellationToken.None );

			state.BuyingPrice.Value.Should().Be(100000);
			state.NotaryFees.Value.Should().Be(7500);
		}
	}
}