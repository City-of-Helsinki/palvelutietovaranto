@BrowserTest
Feature: EditingService

Background: 
	Given the test user is logged in
	And an organization exists with the name 'Daycare Inc.'
	And a service exists for the organization with following details
	| Service name | Alternate name       | Short description | Description                    | Languages     | Requirements        | User instructions                                     | Service classes         | Ontology terms            | Target groups           | Life events                  | Keywords       |
	| Daycare      | Daycare for children | Private daycare   | Daycare to help public daycare | suomi, ruotsi | User must have kids | Bring kids in the morning, take home in the afternoon | Asuminen, Asumisen tuet | työväenopisto, päivähoito | Kansalaiset, Ikäihmiset | Asevelvollisuus, Muuttaminen | Palvelu, Kunta |
	And organization services page is visible
	
Scenario: Service basic information is shown correctly in read mode
	When the service 'Daycare' is selected
	Then following service information is displayed
	| Service name | Alternate name       | Short description | Description                    | Languages     | Requirements        | User instructions                                     |
	| Daycare      | Daycare for children | Private daycare   | Daycare to help public daycare | suomi, ruotsi | User must have kids | Bring kids in the morning, take home in the afternoon |

Scenario: Service basic information is shown correctly in edit mode
	Given the service 'Daycare' is selected
	When the basic information is put in edit mode
	Then following service information is displayed in edit mode
	| Service name | Alternate name       | Short description | Description                    | Languages     | Requirements        | User instructions                                     |
	| Daycare      | Daycare for children | Private daycare   | Daycare to help public daycare | suomi, ruotsi | User must have kids | Bring kids in the morning, take home in the afternoon |
	And save button is disabled

Scenario: Existing service basic information can be edited and edited information is shown correctly
	Given the service 'Daycare' is selected
	And the basic information is put in edit mode
	When The following information is edited
	| Service name | Alternate name           | Short description                | Description                      | Languages | Requirements | User instructions |
	| Daycare      | Daycare for all children | Private daycare for all children | Daycare to assist public daycare | suomi     |              |                   |
	And the service information is saved
	Then following service information is displayed
	| Service name | Alternate name           | Short description                | Description                      | Languages | Requirements | User instructions |
	| Daycare      | Daycare for all children | Private daycare for all children | Daycare to assist public daycare | suomi     |              |                   |
	
Scenario: Service classification information is shown correctly in read mode
	Given the service 'Daycare' is selected
	Then following service classification information is displayed
	| Service classes         | Ontology terms            | Target groups           | Life events                  | Keywords       |
	| Asuminen, Asumisen tuet | työväenopisto, päivähoito | Kansalaiset, Ikäihmiset | Asevelvollisuus, Muuttaminen | Kunta, Palvelu |

Scenario: Service classification information is shown correctly in edit mode
	Given the service 'Daycare' is selected
	And the classification information is put in edit mode
	Then following service classification information is displayed in edit mode
	| Service classes         | Ontology terms            | Target groups           | Life events                  | Keywords       |
	| Asuminen, Asumisen tuet | työväenopisto, päivähoito | Kansalaiset, Ikäihmiset | Asevelvollisuus, Muuttaminen | Kunta, Palvelu |

Scenario: Existing service classification information can be edited and edited information is shown correctly
	Given the service 'Daycare' is selected
	And the classification information is put in edit mode
	When service keywords are cleared
	And service class 'Asumisen tuet' is removed
	And ontology term 'päivähoito' is removed
	And target group 'Ikäihmiset' is removed
	And life event 'Asevelvollisuus' is removed
	And the service classification information is saved
	Then following service classification information is displayed
	| Service classes | Ontology terms | Target groups | Life events | Keywords |
	| Asuminen        | työväenopisto  | Kansalaiset   | Muuttaminen |          |
	And service has no service class 'Asumisen tuet'
	And service has no ontology term 'päivähoito'
	And service has no target group 'Ikäihmiset'
	And service has no life event 'Asevelvollisuus'

Scenario: Cancelling the editing of service basic information changes nothing
	Given the service 'Daycare' is selected
	And the basic information is put in edit mode
	When basic information editing is cancelled
	Then following service information is displayed
	| Service name | Alternate name       | Short description | Description                    | Languages     | Requirements        | User instructions                                     |
	| Daycare      | Daycare for children | Private daycare   | Daycare to help public daycare | suomi, ruotsi | User must have kids | Bring kids in the morning, take home in the afternoon |
	And following service classification information is displayed
	| Service classes         | Ontology terms            | Target groups           | Life events                  | Keywords       |
	| Asuminen, Asumisen tuet | työväenopisto, päivähoito | Kansalaiset, Ikäihmiset | Asevelvollisuus, Muuttaminen | Kunta, Palvelu |

Scenario: Cancelling the editing of service classification information changes nothing
	Given the service 'Daycare' is selected
	And the classification information is put in edit mode
	When classification information editing is cancelled
	Then following service information is displayed
	| Service name | Alternate name       | Short description | Description                    | Languages     | Requirements        | User instructions                                     |
	| Daycare      | Daycare for children | Private daycare   | Daycare to help public daycare | suomi, ruotsi | User must have kids | Bring kids in the morning, take home in the afternoon |
	And following service classification information is displayed
	| Service classes         | Ontology terms            | Target groups           | Life events                  | Keywords       |
	| Asuminen, Asumisen tuet | työväenopisto, päivähoito | Kansalaiset, Ikäihmiset | Asevelvollisuus, Muuttaminen | Kunta, Palvelu |
