using BlazorState;
using ImmoCalc.Domain;

namespace ImmoCalc.Stores.Infos {
	public class InfosState : State<InfosState>
	{
		public BuyingPrice BuyingPrice { get; set; } = BuyingPrice.Empty;

		public override void Initialize()
		{
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
