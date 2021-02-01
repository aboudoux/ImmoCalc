using System;
using ImmoCalc.Tests.Assets;
using TechTalk.SpecFlow;

namespace ImmoCalc.Tests.Steps {
	[Binding]
	public sealed class CurrentProjectSteps 
	{
		private readonly IhmDataContext _context;
		private readonly ProjectIdMapping _mapping;
		private const string Included = "included";
		public CurrentProjectSteps(IhmDataContext context, ProjectIdMapping mapping)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_mapping = mapping ?? throw new ArgumentNullException(nameof(mapping));
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

		[Given(@"I set the (.*) to ""(.*)""")]
		public void GivenISetTheNameTo(string fieldName, string value) {
			_context.ChangeValue(fieldName, value);
		}


		[Given(@"I load the project (.*)")]
		[When(@"I load the project (.*)")]
		public void WhenILoadTheProject(string projectId)
		{
			_context.LoadProject(_mapping.Get(projectId));
		}


		[Then(@"the (.*) value is (.*)")]
		public void ThenTheBuyingPriceValueIs(string fieldName, double value)
		{
			_context.Assert(fieldName, value);
		}

		[Then(@"the (.*) value is ""(.*)""")]
		public void ThenTheBuyingPriceValueIs(string fieldName, string value) {
			_context.Assert(fieldName, value);
		}

		[Given(@"the notary fees are (.*) in loan")]
		public void GivenTheNotaryFeesAreIncludedInLoan(string isIncluded)
		{
			_context.CurrentProjectState.Project.NotaryFees.IncludedInLoanAmount(isIncluded == Included);
		}

		[When(@"I set the notary fees (.*) in loan")]
		public void UpdateNotaryFeesInclude(string isIncluded)
		{
			_context.ChangeNotaryFeesInclude(isIncluded == Included);
		}

		[Given(@"the renovation is (.*) in loan")]
		public void GivenTheRenovationAreIncludedInLoan(string isIncluded) 
		{
			_context.CurrentProjectState.Project.Renovation.IncludedInLoanAmount(isIncluded == Included);
		}

		[When(@"I set the renovation (.*) in loan")]
		public void UpdateRenovationInclude(string isIncluded)
		{
			_context.ChangeRenovationInclude(isIncluded == Included);
		}

		[Given(@"the charges are (.*) in monthly rent")]
		public void GivenTheChargesAreIncludedInMonthlyPayment(string isIncluded)
		{
			_context.CurrentProjectState.Project.Charges.IncludedInMonthlyRent(isIncluded == Included);
		}

		[When(@"I set the charges (.*) in monthly rent")]
		public void UpdateChargesInclude(string isIncluded)
		{
			_context.ChangeChargesInclude(isIncluded == Included);
		}
	}
}
