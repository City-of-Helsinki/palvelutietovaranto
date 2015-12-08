@BrowserTest
Feature: OrganizationTreeTests

Background: 
	Given the test user is logged in

Scenario: Add main new level organization
	Given the organization tree is visible
	And user starts to edit organization tree
	When user starts to create new main organization
	Then new main organization can be created
	And user cancels creating new organization

Scenario: Add new suborganization
	Given the organization tree is visible
	And user starts to edit organization tree
	When user starts to create new suborganization
	Then new suborganization can be created
	And user cancels creating new organization

Scenario: Cancel organization tree editing
	Given the organization tree is visible
	And user starts to edit organization tree
	Then cancel button is visible
	When user cancels editing the structure
	Then cancel button is not visible


