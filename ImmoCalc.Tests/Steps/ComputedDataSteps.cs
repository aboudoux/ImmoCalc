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

		[Given(@"the (.*) is set to (.*)")]
		public void GivenTheBuyingPriceIsSetTo(string fieldName, double value) 
		{
			_context.SetValue(fieldName, value);
		}

		[When(@"I set the (.*) to (.*)")]
		public void WhenISetTheBuyingPriceTo(string fieldName, double value)
		{
			_context.ChangeValue(fieldName, value);
		}

		[Then(@"the (.*) value is (.*)")]
		public void ThenTheBuyingPriceValueIs(string fieldName, double value)
		{
			_context.Assert(fieldName, value);
		}

		[Given(@"the notary fees are (.*) in loan")]
		public void GivenTheNotaryFeesAreIncludedInLoan(string isIncluded)
		{
			_context.State.NotaryFees.IncludedInLoanAmount(isIncluded == "included");
		}

		[Given(@"the renovation are (.*) in loan")]
		public void GivenTheRenovationAreIncludedInLoan(string isIncluded) 
		{
			_context.State.Renovation.IncludedInLoanAmount(isIncluded == "included");
		}
	}
}
