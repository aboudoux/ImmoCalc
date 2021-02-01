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


Scenario: Create a new project
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
	| Name        | Address                      |
	| Appart 1    | 1 avenue de mars, 69001 lyon |
	| Appart 2    | 2 impasse dufour, 69002 lyon |
	| APPART TEST | 10 rue du test               |

Scenario: Load a project
Given some projects stored in a database
	| Id | Name     | Address                      | 
	| 1  | Appart 1 | 1 avenue de mars, 69001 lyon | 
	| 2  | Appart 2 | 2 impasse dufour, 69002 lyon |
When I load the project 2
Then the name value is "Appart 2"
And the address value is "2 impasse dufour, 69002 lyon"

Scenario: Update an existing project
Given some projects stored in a database
	| Id | Name     | Address                      | 
	| 1  | Appart 1 | 1 avenue de mars, 69001 lyon | 
	| 2  | Appart 2 | 2 impasse dufour, 69002 lyon |
And I load the project 2
And I set the name to "APPART TEST"
And I set the address to "10 rue du test"
When I save the project
And I want to see the stored project
Then the stored projects list is
	| Name        | Address                      |
	| Appart 1    | 1 avenue de mars, 69001 lyon |
	| APPART TEST | 10 rue du test               |

Scenario: Remove a project
Given some projects stored in a database
	| Id | Name     | Address                      | 
	| 1  | Appart 1 | 1 avenue de mars, 69001 lyon | 
	| 2  | Appart 2 | 2 impasse dufour, 69002 lyon |
And I want to see the stored project
When I remove the project 1
Then the stored projects list is
	| Name        | Address                      |
	| Appart 2    | 2 impasse dufour, 69002 lyon |