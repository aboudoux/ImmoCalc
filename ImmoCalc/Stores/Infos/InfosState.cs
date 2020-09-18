using BlazorState;
using ImmoCalc.Domain;

namespace ImmoCalc.Stores.Infos {
	public class InfosState : State<InfosState>
	{
		public BuyingPrice BuyingPrice { get; set; }
		public MonthlyRent MonthlyRent { get; set; }
		public Charges Charges { get; set; }
		public Surface Surface { get; set; }
		public PropertyTax PropertyTax { get; set; }
		public Renovation Renovation { get; set; }


		public LoanDuration LoanDuration { get; set; }
		public LoanRate LoanRate { get; set; }
		public InsuranceRate InsuranceRate { get; set; }


		public NotaryFees NotaryFees { get; private set; }
		public LoanAmount LoanAmount { get; private set; }
		public PropertyTotalCost PropertyTotalCost { get; private set; }
		public SquareMeterPrice SquareMeterPrice { get; private set; }
		public MonthlyIncome MonthlyIncome { get; private set; }
		public TotalMonthlyPayment TotalMonthlyPayment { get; private set; }
		public MonthlyGain MonthlyGain { get; private set; }
		public Profitability Profitability { get; private set; }
		public Contribution Contribution { get; private set; }
		public Score Score { get; private set; }


		public override void Initialize()
		{
			BuyingPrice = BuyingPrice.Empty;
			MonthlyRent = MonthlyRent.Empty;
			Charges = Charges.Empty;
			Surface = Surface.Empty;
			PropertyTax = PropertyTax.Empty;
			Renovation = Renovation.Empty;

			LoanDuration = LoanDuration.Empty;
			LoanRate = LoanRate.Empty;
			InsuranceRate = InsuranceRate.Empty;

			NotaryFees = NotaryFees.Empty;
			LoanAmount = LoanAmount.Empty;
			PropertyTotalCost = PropertyTotalCost.Empty;
			SquareMeterPrice = SquareMeterPrice.Empty;
			MonthlyIncome = MonthlyIncome.Empty;
			TotalMonthlyPayment = TotalMonthlyPayment.Empty;
			MonthlyGain = MonthlyGain.Empty;
			Profitability = Profitability.Empty;
			Contribution = Contribution.Empty;

			Score = Score.Empty;
		}

		public void Compute()
		{
			if (BuyingPrice.IsDefined())
			{
				NotaryFees = NotaryFees.Of(BuyingPrice).IncludedInLoanAmount(NotaryFees.IsIncludedInLoadAmount);
				if(Surface.IsDefined())
					SquareMeterPrice = SquareMeterPrice.Of(BuyingPrice, Surface);

				LoanAmount = LoanAmount.Of(BuyingPrice, NotaryFees, Renovation);
				Contribution= Contribution.Of(NotaryFees, Renovation);
				PropertyTotalCost = PropertyTotalCost.Of(BuyingPrice, Renovation);
			}

			if(MonthlyRent.IsDefined())
				MonthlyIncome = MonthlyIncome.Of(MonthlyRent, Charges, PropertyTax);

			if (LoanAmount.IsDefined() && 
			    LoanDuration.IsDefined() && 
			    LoanRate.IsDefined() &&
			    InsuranceRate.IsDefined())
			{
				TotalMonthlyPayment = TotalMonthlyPayment.Of(MonthlyPayment.Of(LoanAmount, LoanDuration, LoanRate), InsuranceMonthlyPayment.Of(BuyingPrice, InsuranceRate));
			}

			if(MonthlyIncome.IsDefined() && TotalMonthlyPayment.IsDefined())
				MonthlyGain = MonthlyGain.Of(TotalMonthlyPayment, MonthlyIncome);

			if(MonthlyIncome.IsDefined() && BuyingPrice.IsDefined())
				Profitability = Profitability.Of(BuyingPrice, MonthlyIncome);

			if( Profitability.IsDefined() && MonthlyGain.IsDefined())
				Score = Score.Of(Profitability, MonthlyGain, Charges, PropertyTax);
		}
		
		public class ChangeValue : IAction
		{
			public IValue Value { get; }
			public ChangeValue(IValue value) => Value = value;
		}

		public abstract class IncludeAction : IAction {
			public bool Include { get; }
			protected IncludeAction(bool include) => Include = include;
		}

		public class IncludeChargesInMonthlyRent : IncludeAction {
			public IncludeChargesInMonthlyRent(bool include) : base(include) { }
		}

		public class IncludeRenovationInLoadAmount : IncludeAction {
			public IncludeRenovationInLoadAmount(bool include) : base(include) { }
		}

		public class IncludeNotaryFeesInLoadAmount : IncludeAction {
			public IncludeNotaryFeesInLoadAmount(bool include) : base(include) { }
		}
	}
}
