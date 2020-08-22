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
	And the renovation is <Renovation> in loan
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


Scenario Outline: Compute total monthly payment
	Given the loan duration is set to 15
	And the loan rate is set to 1.35
	And the insurance rate is set to 0.10
	And the notary fees are <NotaryFees> in loan
	And the renovation is <Renovation> in loan
	When I set the buying price to 139000
	And I set the renovation to 23000
	Then the total monthly payment value is <TotalMonthlyPayment>
	And the notary fees value is 10425
	And the loan amount value is <LoanAmount>
Examples: 
| NotaryFees   | Renovation   | LoanAmount | TotalMonthlyPayment |
| not included | not included | 139000     | 865                 |
| included     | not included | 149425     | 929                 |
| not included | included     | 162000     | 1007                |
| included     | included     | 172425     | 1071                |

Scenario Outline: Compute monthly gain
Given the loan duration is set to 15
	And the loan rate is set to 1.35
	And the insurance rate is set to 0.10
	And the charges is set to <ChargesPrice>
	And the notary fees are not included in loan
	And the charges are <Charges> in monthly rent
	And the renovation is set to 23000
	And the renovation is <Renovation> in loan
	And the buying price is set to 139000	
	When I set the monthly rent to <MonthlyRent>
	Then the monthly gain value is <MonthlyGain>
Examples: 
| ChargesPrice | Charges      | Renovation   | MonthlyRent | MonthlyGain |
| 80           | included     | not included | 880         | -65         |
| 80           | not included | not included | 880         | 15          |

Scenario: Compute profitability
	Given the buying price is set to 139000	
	And the monthly rent is set to 800
	When I set the property tax to 600
	Then the profitability value is 0.0602

Scenario: Compute contribution
Given the buying price is set to <BuyingPrice>
	And the renovation is set to 0
	And the notary fees are <NotaryFees> in loan
	And the renovation is <Renovation> in loan
	When I set the renovation to <RenovationPrice>
	Then the contribution value is <Contribution>
Examples: 
| BuyingPrice | RenovationPrice | NotaryFees   | Renovation   | Contribution |
| 100000      | 10000           | included     | included     | 0            |
| 100000      | 10000           | not included | included     | 7500         |
| 100000      | 10000           | included     | not included | 10000        |
| 100000      | 10000           | not included | not included | 17500        |

Scenario Outline: Compute score
When I set the buying price to <BuyingPrice>
And I set the monthly rent to <MonthRent>
And I set the charges to <Charges>
And I set the charges <ChargesI> in monthly rent
And I set the property tax to <PropertyTax>
And I set the renovation to <Renovation>
And I set the renovation <RenovationI> in loan
And I set the notary fees <NotaryFeesI> in loan
And I set the loan duration to <LoanDuration>
And I set the loan rate to <LoanRate>
And I set the insurance rate to <InsuranceRate>
Then the score value is <ScoreValue>

Examples: 
| BuyingPrice | MonthRent | Charges | ChargesI    | PropertyTax | Renovation | RenovationI  | LoanDuration | LoanRate | InsuranceRate | NotaryFeesI  | ScoreValue |
| 100000      | 500       | 100     | no included | 600         | 8000       | not included | 15           | 1.35     | 0.10          | not included | 2.19       |
| 139000      | 800       | 80      | no included | 600         | 2000       | not included | 15           | 1.35     | 0.10          | not included | 3.34       |
| 80000       | 560       | 110     | no included | 864         | 0          | not included | 15           | 1.35     | 0.10          | not included | 4.63       |
| 80000       | 560       | 110     | no included | 864         | 0          | not included | 20           | 1.35     | 0.10          | not included | 6.01       |
