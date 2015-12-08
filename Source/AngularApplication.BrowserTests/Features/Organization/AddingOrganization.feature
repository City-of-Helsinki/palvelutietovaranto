@BrowserTest
Feature: AddingOrganization

Background: 
	Given the test user is logged in
	And the user is starting to add a new organization

Scenario: Wizard steps navigation validation
	Given mandatory fields are filled
	And step two of the form is available
	When mandatory information is saved and user moves to step two
	Then save and move to the step three is available
	And go back to step one is available
	And save step two and quit is available
	When user moves to step three
	Then move to the step four is available
	And go back to step two is available
	And save step three and quit is available
	When user moves to step four
	Then step four can be saved
	And go back to step three is available
	When user goes back to step three
	Then move to the step four is available
	And go back to step two is available
	And save step three and quit is available
	When user goes back to step two
	Then save and move to the step three is available
	And go back to step one is available
	And step two can be saved
	When user goes back to step one
	Then move to the step two is available
	And step one can be saved

Scenario: Mandatory information must be filled before organization can be saved
	Then organization cannot be saved
	When provider type 'Kunta' is selected
	Then organization cannot be saved
	When municipality code '12' is typed
	Then organization cannot be saved
	When name 'Turku' is typed
	Then organization cannot be saved
	When business id '1234567-1' is typed
	And focus is moved out of the business id form field
	Then organization can be saved

Scenario: Municipality code can only be entered for a municipality organization
	When provider type 'Yritykset' is selected
	Then municipality code field is not visible
	When provider type 'Kunta' is selected
	Then municipality code field is visible

Scenario: Business identifier is validated
	Given provider type 'Yritykset' is selected
	And name 'Turku' is typed
	When business id '123456-1' is typed
	And focus is moved out of the business id form field
	Then organization cannot be saved
	And business id error message is displayed
	When business id '1234567-1' is typed
	And focus is moved out of the business id form field
	Then organization can be saved
	And business id error message is not displayed

Scenario: Contact information is validated 
	Given mandatory fields are filled
	Then step two of the form is available
	And mandatory information is saved and user moves to contact information step
	When phone number 'asdas346' is typed
	And focus is moved out of the phone number form field
	Then phone error message is shown
	And contact information cannot be saved
	When phone number '0401234567' is typed
	And focus is moved out of the phone number form field
	And phone call price '1€/h' is typed
	And focus is moved from phone number price form field
	When email 'jani.gronman@affecto' is typed
	And focus is moved from email form field
	Then email error message is shown
	And contact information cannot be saved
	When email 'jani.gronman@affecto.com' is typed
	And focus is moved from email form field
	Then email error message is not shown
	And contact information can be saved
	When focus is moved to web address name
	Then web address cannot be saved
	When web address 'google' is typed
	And focus is moved to web address name
	Then web address error message is shown
	And web address can not be saved
	When web address 'google.com' is typed
	And focus is moved to web address name
	Then web address can not be saved
	When web address name 'Google front page' is typed
	Then web address can not be saved
	When web address type 'Kotisivu' is selected
	Then web address can be saved
	When web address is saved
	Then web address list should contain 'Google front page'
	And web address list should contain 'http://google.com'
	And web address list should contain 'Kotisivu'
	When user clicks edit on the list item 'Google front page'
	Then web address list item can be saved
	And web address list item editing can be canceled
	And web address can not be saved
	When web address name '' is typed on the list item
	Then web address list item can not be saved
	When web address list item editing is canceled
	Then web address list should contain 'Google front page'
	When web address list item 'Google front page' is deleted
	Then list should not contain item 'Google front page'
	When web address 'google.com' is typed
	And web address name 'Google front page' is typed
	And web address type 'Kotisivu' is selected
	Then web address can be saved
	And web address is saved
	And user saves the contact information and moves to the step three of the form

Scenario: street address information is validated
	Given mandatory fields are filled
	And step two of the form is available
	When mandatory information is saved and user moves to step two
	Then save and move to the step three is available
	And user moves to step three
	And street address 'Osoite 15 a 3' is typed
	Then street address information cannot be saved
	When postal code '33500' is typed
	Then street address information cannot be saved
	When postal location 'Tampere' is typed
	Then street address information can be saved
	And street address information is saved

Scenario: postal address information is validated
	Given mandatory fields are filled
	And step two of the form is available
	When mandatory information is saved and user moves to step two
	Then save and move to the step three is available
	And user moves to step three
	Then move to the step four is available
	And user moves to step four
	Then select postal address type dropdown should be available
	And dropdown should contain 'PL-osoite'
	And dropdown should contain 'Muu osoite'
	
	When item 'PL-osoite' is selected
	Then add new postal box address should be available
	And another item can be selected from dropdown
	And this postal box address can be deleted
	When postbox 'XX' is typed
	Then postbox error message is shown
	And postal address information cannot be saved
	When postbox postal code '33500' is typed
	Then postal code error message is shown
	And postal address information cannot be saved
	When postbox postal code '3350' is typed
	Then postal code error message is shown
	And postal address information cannot be saved
	And save postal address information and go back is not available

	When postbox '66' is typed
	Then postal address information cannot be saved
	And postbox error message is not shown
	When postbox postal code '33501' is typed
	Then postal address information cannot be saved
	And postal code error message is not shown
	When city 'Tampere' is typed
	Then postal address information can be saved
	And this postal box address can be deleted
	And save postal address information and go back is available

	When item 'Muu osoite' is selected
	Then add new separate postal address should be available
	And another item cannot be selected from dropdown
	And this separate postal address can be deleted
	When separate street address 'Katuosoite 34 D78' is typed
	Then postal address information cannot be saved
	When separate street address postal code '330saX' is typed
	Then separate street address postal code error message is shown 
	And postal address information cannot be saved
	When separate street address postal code '33500' is typed
	Then separate street address postal code error message is not shown
	And postal address information cannot be saved
	When separate postal address district 'Tampere' is typed
	Then postal address information can be saved
	And this separate postal address can be deleted
	And save postal address information and go back is available
