@BrowserTest
Feature: AddingService
	
Background: 
	Given an organization exists with the name 'Daycare Inc.'
	And the test user is logged in
	And the user is starting to add a new service

Scenario: Mandatory basic information must be filled before the service can be saved
	Then service cannot be saved
	When service name 'Daycare' has been entered
	Then service cannot be saved
	When the short description 'Päivähoito lapsille' has been entered for the service
	Then service cannot be saved
	When the service description 'Tämä päivähoito on tarkoitettu lähialueen lapsille' has been entered
	Then service cannot be saved
	When 'suomi' as language has been selected
	Then service can be saved

Scenario: Saving service basic information
	Given the following service basic information is typed:
	| Name    | Description         | Short description | Language |
	| Daycare | Päivähoito lapsille | Päivähoito        | suomi    |
	When the service is saved
	Then the user is redirected to the organization's service list
	And the list contains service 'Daycare'

Scenario: Cancelling adding a new service
	When adding a service is cancelled
	Then the user is redirected to the organization's service list

Scenario: Mandatory classification information must be selected before the classification information can be saved
	Given service basic information is filled
	And the user moves forward to the classification section
	Then classification information cannot be saved
	When service class 'Asuminen' is selected
	Then classification information cannot be saved
	When ontology term 'opetus' is selected
	Then classification information cannot be saved
	When target group 'Yritykset' is selected
	Then classification information can be saved

Scenario: Selecting service classes
	Given service basic information is filled
	And the user moves forward to the classification section

	When 'Omistus' is typed to the service class search field
	And service class 'Omistusasuminen' is selected
	Then service class 'Omistusasuminen' is selected
	And service class 'Asuminen' is selected

	When service class selection 'Asuminen' is removed
	Then service class 'Omistusasuminen' is not selected
	And service class 'Asuminen' is not selected

Scenario: Selecting ontology terms
	Given service basic information is filled
	And the user moves forward to the classification section

	When ontology term 'kielet (opetus)' is selected
	Then ontology term 'kielet (opetus)' is selected

	When ontology term selection 'kielet (opetus)' is removed
	Then ontology term 'kielet (opetus)' is not selected

Scenario: Selecting target groups
	Given service basic information is filled
	And the user moves forward to the classification section

	When 'K' is typed to the target group search field
	And target group 'Ikäihmiset' is selected
	Then target group 'Kansalaiset' is selected
	And target group 'Ikäihmiset' is selected

	When target group selection 'Ikäihmiset' is removed
	Then target group 'Ikäihmiset' is not selected
	And target group 'Kansalaiset' is selected

Scenario: Selecting life events
	Given service basic information is filled
	And the user moves forward to the classification section

	When 'mu' is typed to the life event search field
	And life event 'Paluumuutto Suomeen' is selected
	Then life event 'Muuttaminen' is selected
	And life event 'Paluumuutto Suomeen' is selected

	When life event selection 'Muuttaminen' is removed
	Then life event 'Muuttaminen' is not selected
	And life event 'Paluumuutto Suomeen' is not selected

Scenario: Saving service classification
	Given service basic information is filled
	And the user moves forward to the classification section
	And service class 'Asuminen' is selected
	And service class 'Perheiden palvelut' is selected
	And ontology term 'opetus' is selected
	And target group 'Yritykset' is selected
	
	When service classification is saved
	Then the user is redirected to the organization's service list
	And the listed service contains ontology terms 'opetus'
	And the listed service contains service classes 'Asuminen, Perheiden palvelut'
