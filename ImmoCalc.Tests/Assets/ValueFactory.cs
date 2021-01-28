using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ImmoCalc.Domain;
using ImmoCalc.Stores.CurrentProject;
using TypeSupport.Extensions;

namespace ImmoCalc.Tests.Assets
{
	public static class ValueFactory
	{
		private static readonly Dictionary<string, (Func<double, IValue> valueMaker, Expression<Func<CurrentProjectState, IValue>> property) > Builders = new Dictionary<string, (Func<double, IValue> valueMaker, Expression<Func<CurrentProjectState, IValue>> property)>()
		{
			{"buying price", (BuyingPrice.From, a=>a.BuyingPrice )},
			{"monthly rent", (MonthlyRent.From,a=>a.MonthlyRent)},
			{"charges", (Charges.From,a=>a.Charges)},
			{"surface", (Surface.From, a=>a.Surface)},
			{"property tax", (PropertyTax.From,a=>a.PropertyTax)},
			{"renovation", (Renovation.From,a=>a.Renovation)},

			{"loan duration", (a=>LoanDuration.From((int)a),a=>a.LoanDuration)},
			{"loan rate", (LoanRate.From,a=>a.LoanRate)},
			{"insurance rate", (InsuranceRate.From,a=>a.InsuranceRate)},
			{"notary fees", (null,a=>a.NotaryFees)},
			{"loan amount", (null,a=>a.LoanAmount)},

			{"property total cost", (null,a=>a.PropertyTotalCost)},
			{"square meter price", (null,a=>a.SquareMeterPrice)},
			{"monthly income", (null,a=>a.MonthlyIncome)},
			{"total monthly payment", (null,a=>a.TotalMonthlyPayment)},
			{"monthly gain", (null,a=>a.MonthlyGain)},
			{"profitability", (null,a=>a.Profitability)},
			{"contribution", (null,a=>a.Contribution)},
			{"score", (null,a=>a.Score)},
		};

		public static IValue Get(string fieldName, double value) => Builders[fieldName].valueMaker(value);

		public static void SetState(CurrentProjectState state, string fieldName, double value)
		{
			var name = GetExpressionName(Builders[fieldName].property);
			state.SetPropertyValue(name, Builders[fieldName].valueMaker(value));
		}

		public static IValue GetState(CurrentProjectState state, string fieldName)
		{
			return state.GetPropertyValue(GetExpressionName(Builders[fieldName].property)) as IValue;
		}

		private static string GetExpressionName(Expression<Func<CurrentProjectState, IValue>> expression)
		{
			var ex = (MemberExpression) expression.Body;
			return ex.Member.Name;
		}
	}
}