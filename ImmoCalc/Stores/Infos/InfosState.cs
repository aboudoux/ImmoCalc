using BlazorState;
using ImmoCalc.Domain;

namespace ImmoCalc.Stores.Infos {
	public class InfosState : State<InfosState>
	{
		public BuyingPrice BuyingPrice { get; set; }
		public NotaryFees NotaryFees { get; set; }

		public override void Initialize()
		{
			BuyingPrice = BuyingPrice.Empty;
			NotaryFees = NotaryFees.Empty;
		}

		public class ChangeBuyingPrice : IAction
		{
			public BuyingPrice BuyingPrice { get; }

			public ChangeBuyingPrice(BuyingPrice buyingPrice)
			{
				BuyingPrice = buyingPrice;
			}
		}
	}
}
