Feature: Basic navigation to Manage Clients Page
	
@smoke @positive
Scenario: Checking the basic login flow
	Given User navigates to the application
	And User validates the application is opened
	When User enters SecureID
	Then User clicks on Submit
	Then User validates the login was successful

Scenario: Checking the basic flow till Manage Clients Page
	Given User navigates to the application
	And User validates the application is opened
	When User enters SecureID
	Then User clicks on Submit
	#Then User clicks on Client Tab
	#Then User clicks on Manage Client
	#Then User validates the navigation to Manage Clients was successful
