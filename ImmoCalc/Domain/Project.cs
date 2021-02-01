namespace ImmoCalc.Domain
{
	public class Project
	{
		public Project(ProjectId projectId)
		{
			ProjectId = projectId;
			BuyingPrice = BuyingPrice.Empty;
			MonthlyRent = MonthlyRent.Empty;
			Charges = Charges.Empty;
			Surface = Surface.Empty;
			PropertyTax = PropertyTax.Empty;
			Renovation = Renovation.Empty;

			LoanDuration = LoanDuration.From(15);
			LoanRate = LoanRate.From(1.3);
			InsuranceRate = InsuranceRate.From(1);

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

			Name = ProjectName.Empty;
			Address = Address.Empty;
		}

		public ProjectId ProjectId { get; }
		public ProjectName Name { get; set; }
		public Address Address { get; set; }

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

		public void Compute() 
		{
			if (BuyingPrice.IsDefined()) {
				NotaryFees = NotaryFees.Of(BuyingPrice).IncludedInLoanAmount(NotaryFees.IsIncludedInLoadAmount);
				if (Surface.IsDefined())
					SquareMeterPrice = SquareMeterPrice.Of(BuyingPrice, Surface);

				LoanAmount = LoanAmount.Of(BuyingPrice, NotaryFees, Renovation);
				Contribution = Contribution.Of(NotaryFees, Renovation);
				PropertyTotalCost = PropertyTotalCost.Of(BuyingPrice, Renovation);
			}

			if (MonthlyRent.IsDefined())
				MonthlyIncome = MonthlyIncome.Of(MonthlyRent, Charges, PropertyTax);

			if (LoanAmount.IsDefined() &&
			    LoanDuration.IsDefined() &&
			    LoanRate.IsDefined() &&
			    InsuranceRate.IsDefined()) {
				TotalMonthlyPayment = TotalMonthlyPayment.Of(MonthlyPayment.Of(LoanAmount, LoanDuration, LoanRate), InsuranceMonthlyPayment.Of(BuyingPrice, InsuranceRate));
			}

			if (MonthlyIncome.IsDefined() && TotalMonthlyPayment.IsDefined())
				MonthlyGain = MonthlyGain.Of(TotalMonthlyPayment, MonthlyIncome);

			if (MonthlyIncome.IsDefined() && BuyingPrice.IsDefined())
				Profitability = Profitability.Of(BuyingPrice, MonthlyIncome);

			if (Profitability.IsDefined() && MonthlyGain.IsDefined())
				Score = Score.Of(Profitability, MonthlyGain, Charges, PropertyTax);
		}
	}
}