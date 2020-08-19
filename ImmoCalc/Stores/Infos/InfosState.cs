using BlazorState;
using ImmoCalc.Domain;

namespace ImmoCalc.Stores.Infos {
	public class InfosState : State<InfosState>
	{
		public BuyingPrice BuyingPrice { get; set; }
		public NotaryFees NotaryFees { get; set; }
		public MonthlyRent MonthlyRent { get; set; }
		public RateOfReturn RateOfReturn { get; set; }
		public MonthlyGain MonthlyGain { get; set; }

		public override void Initialize()
		{
			BuyingPrice = BuyingPrice.Empty;
			NotaryFees = NotaryFees.Empty;
			MonthlyRent = MonthlyRent.Empty;
			RateOfReturn = RateOfReturn.Empty;
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
	}
}
