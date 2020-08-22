using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ImmoCalc.Domain;
using ImmoCalc.Stores.Infos;
using TypeSupport.Extensions;

namespace ImmoCalc.Tests.Assets
{
	public static class ValueFactory
	{
		private static readonly Dictionary<string, (Func<double, IValue> valueMaker, Expression<Func<InfosState, IValue>> property) > Builders = new Dictionary<string, (Func<double, IValue> valueMaker, Expression<Func<InfosState, IValue>> property)>()
		{
			{"buying price", (BuyingPrice.From, a=>a.BuyingPrice )},
			{"surface", (Surface.From, a=>a.Surface)},
			{"square meter price", (null,a=>a.SquareMeterPrice)},
			{"notary fees", (null,a=>a.NotaryFees)},
			{"renovation", (Renovation.From,a=>a.Renovation)},
			{"loan amount", (null,a=>a.LoanAmount)},
			{"property total cost", (null,a=>a.PropertyTotalCost)},
			{"monthly rent", (MonthlyRent.From,a=>a.MonthlyRent)},
			{"charges", (Charges.From,a=>a.Charges)},
			{"property tax", (PropertyTax.From,a=>a.PropertyTax)},
			{"monthly income", (null,a=>a.MonthlyIncome)},
			{"total monthly payment", (null,a=>a.TotalMonthlyPayment)},
			{"loan duration", (a=>LoanDuration.From((int)a),a=>a.LoanDuration)},
			{"loan rate", (LoanRate.From,a=>a.LoanRate)},
			{"Insurance rate", (InsuranceRate.From,a=>a.InsuranceRate)},
			{"monthly gain", (null,a=>a.MonthlyGain)},
			{"profitability", (null,a=>a.Profitability)},
			{"contribution", (null,a=>a.Contribution)},
		};

		public static IValue Get(string fieldName, double value) => Builders[fieldName].valueMaker(value);

		public static void SetState(InfosState state, string fieldName, double value)
		{
			var name = GetExpressionName(Builders[fieldName].property);
			state.SetPropertyValue(name, Builders[fieldName].valueMaker(value));
		}

		public static IValue GetState(InfosState state, string fieldName)
		{
			return state.GetPropertyValue(GetExpressionName(Builders[fieldName].property)) as IValue;
		}

		private static string GetExpressionName(Expression<Func<InfosState, IValue>> expression)
		{
			var ex = (MemberExpression) expression.Body;
			return ex.Member.Name;
		}
	}
}