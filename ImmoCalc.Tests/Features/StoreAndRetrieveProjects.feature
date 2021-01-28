Feature: StoreAndRetrieveProjects
	As a user
	I want to be able to manage my project by listing, removing, creating and updating them
	in an external storage

Scenario: List my existing projects
	Given some projects stored in a database
	| Id | Name     | Address                      | 
	| 1  | Appart 1 | 1 avenue de mars, 69001 lyon | 
	| 2  | Appart 2 | 2 impasse dufour, 69002 lyon |
	When I want to see the stored project
	Then the stored projects list is
	| Name     | Address                      |
	| Appart 1 | 1 avenue de mars, 69001 lyon |
	| Appart 2 | 2 impasse dufour, 69002 lyon |


Scenario: Create e new project
Given some projects stored in a database
	| Id | Name     | Address                      | 
	| 1  | Appart 1 | 1 avenue de mars, 69001 lyon | 
	| 2  | Appart 2 | 2 impasse dufour, 69002 lyon |
And I create a new project
And I set the name to "APPART TEST"
And I set the address to "10 rue du test"
And I save the project
When I want to see the stored project
Then the stored projects list is
	| Address     | Address                      |
	| Appart 1    | 1 avenue de mars, 69001 lyon |
	| Appart 2    | 2 impasse dufour, 69002 lyon |
	| APPART TEST | 10 rue du test               |