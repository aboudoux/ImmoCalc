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
		private static readonly Dictionary<string, (Func<object, IValueObject> valueMaker, Expression<Func<CurrentProjectState, IValueObject>> property)> Builders 
			= new Dictionary<string, (Func<object, IValueObject> valueMaker, Expression<Func<CurrentProjectState, IValueObject>> property)>()
		{
			{"buying price", (b=>BuyingPrice.From((double)b), a=>a.Project.BuyingPrice )},
			{"monthly rent", (b=>MonthlyRent.From((double)b),a=>a.Project.MonthlyRent)},
			{"charges", (b=>Charges.From((double)b),a=>a.Project.Charges)},
			{"surface", (b=>Surface.From((double)b), a=>a.Project.Surface)},
			{"property tax", (b=>PropertyTax.From((double)b),a=>a.Project.PropertyTax)},
			{"renovation", (b=>Renovation.From((double)b),a=>a.Project.Renovation)},

			{"loan duration", (a=>LoanDuration.From(Convert.ToInt32(a)),a=>a.Project.LoanDuration)},
			{"loan rate", (b=>LoanRate.From((double)b),a=>a.Project.LoanRate)},
			{"insurance rate", (b=>InsuranceRate.From((double)b),a=>a.Project.InsuranceRate)},
			{"notary fees", (null,a=>a.Project.NotaryFees)},
			{"loan amount", (null,a=>a.Project.LoanAmount)},

			{"property total cost", (null,a=>a.Project.PropertyTotalCost)},
			{"square meter price", (null,a=>a.Project.SquareMeterPrice)},
			{"monthly income", (null,a=>a.Project.MonthlyIncome)},
			{"total monthly payment", (null,a=>a.Project.TotalMonthlyPayment)},
			{"monthly gain", (null,a=>a.Project.MonthlyGain)},
			{"profitability", (null,a=>a.Project.Profitability)},
			{"contribution", (null,a=>a.Project.Contribution)},
			{"score", (null,a=>a.Project.Score)},

			{"name",(b=>ProjectName.From((string)b), a=>a.Project.Name)},
			{"address",(b=>Address.From((string)b), a=>a.Project.Address)},
		};

		public static IValueObject Get(string fieldName, object value) => Builders[fieldName.ToLower()].valueMaker(value);

		public static void SetState(CurrentProjectState state, string fieldName, double value)
		{
			var name = GetExpressionName(Builders[fieldName].property);
			state.Project.SetPropertyValue(name, Builders[fieldName.ToLower()].valueMaker(value));
		}

		public static IValueObject GetState(CurrentProjectState state, string fieldName)
		{
			return state.Project.GetPropertyValue(GetExpressionName(Builders[fieldName.ToLower()].property)) as IValueObject;
		}

		private static string GetExpressionName(Expression<Func<CurrentProjectState, IValueObject>> expression)
		{
			var ex = (MemberExpression) expression.Body;
			return ex.Member.Name;
		}
	}
}