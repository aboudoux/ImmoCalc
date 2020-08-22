Feature: Compute feature
	As an investissor, 
	I want to have some metrics about a properties
	To know if it is a good investment

Scenario: Compute notary fees	
	When I set the buying price to 100000
	Then the buying price value is 100000
	And the notary fees value is 7500

Scenario: Compute square meter price
	Given the buying price is set to 100000
	When I set the surface to 25
	Then the surface value is 25
	And the square meter price value is 4000

Scenario Outline: Compute loan amount
	Given the buying price is set to <BuyingPrice>
	And the renovation is set to 0
	And the notary fees are <NotaryFees> in loan
	And the renovation are <Renovation> in loan
	When I set the renovation to <RenovationPrice>
	Then the loan amount value is <LoanAmount>
Examples: 
| BuyingPrice | RenovationPrice | NotaryFees   | Renovation   | LoanAmount |
| 100000      | 10000           | included     | included     | 117500     |
| 100000      | 10000           | not included | included     | 110000     |
| 100000      | 10000           | included     | not included | 107500     |
| 100000      | 10000           | not included | not included | 100000     |


Scenario: Compute property total cost
Given the buying price is set to 100000
When I set the renovation to 5000
Then the property total cost value is 112500

Scenario Outline: Compute monthly income
	Given the monthly rent is set to <MonthlyRent>
	And the charges is set to <ChargesPrice>
	And the charges are <Charges> in monthly rent
	When I set the property tax to <PropertyTax>
	Then the monthly income value is <MonthlyIncome>
Examples: 
| MonthlyRent | ChargesPrice | Charges      | PropertyTax | MonthlyIncome |
| 880         | 80           | included     | 600         | 750           |
| 880         | 80           | not included | 600         | 830           |

