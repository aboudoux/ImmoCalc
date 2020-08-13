using BlazorState;
using ImmoCalc.Domain;

namespace ImmoCalc.Stores.Infos {
	public class InfosState : State<InfosState>
	{
		public string BuyingPrice { get; set; }
		public string NotaryFees { get; set; }

		public override void Initialize()
		{
		}

		public class ChangeBuyingPrice : IAction
		{
			public string BuyingPrice { get; }

			public ChangeBuyingPrice(string buyingPrice)
			{
				BuyingPrice = buyingPrice;
			}
		}
	}
}
