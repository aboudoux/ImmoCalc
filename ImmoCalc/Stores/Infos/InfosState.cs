﻿using BlazorState;
using ImmoCalc.Domain;

namespace ImmoCalc.Stores.Infos {
	public class InfosState : State<InfosState>
	{
		public BuyingPrice BuyingPrice { get; set; }
		public NotaryFees NotaryFees { get; set; }
		public MonthlyRent MonthlyRent { get; set; }
		public Profitability Profitability { get; set; }
		public MonthlyGain MonthlyGain { get; set; }
		public MonthlyPayment MonthlyPayment { get; set; }
		public Charges Charges { get; set; }

		public override void Initialize()
		{
			BuyingPrice = BuyingPrice.Empty;
			NotaryFees = NotaryFees.Empty;
			MonthlyRent = MonthlyRent.Empty;
			Profitability = Profitability.Empty;
			MonthlyGain = MonthlyGain.Empty;
			MonthlyPayment = MonthlyPayment.Empty;
		}

		public class ChangeBuyingPrice : IAction
		{
			public BuyingPrice BuyingPrice { get; }

			public ChangeBuyingPrice(BuyingPrice buyingPrice)
			{
				BuyingPrice = buyingPrice;
			}
		}

		public class ChangeMonthlyRent : IAction
		{
			public MonthlyRent MonthlyRent { get; }

			public ChangeMonthlyRent(MonthlyRent monthlyRent)
			{
				MonthlyRent = monthlyRent;
			}
		}

		public class ChangeCharges : IAction
		{
			public Charges Charges { get; }

			public ChangeCharges(Charges charges)
			{
				Charges = charges;
			}
		}
	}
}
