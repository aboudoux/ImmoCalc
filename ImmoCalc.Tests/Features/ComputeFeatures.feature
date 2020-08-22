Feature: Compute feature
	As an investissor, 
	I want to have some metrics about a properties
	To know if it is a good investment

Scenario: Compute notary fees	
	When I set the buying price to 100000
	Then the buying price value is 100000
	And the notary fees value is 7500