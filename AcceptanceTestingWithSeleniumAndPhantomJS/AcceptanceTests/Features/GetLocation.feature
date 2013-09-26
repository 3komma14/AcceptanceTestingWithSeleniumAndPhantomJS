Feature: GetLocation
	In order to avoid silly mistakes
	As a user
	I want to know my current location

Background: 
	Given I have opened the webpage

Scenario: Get current ip address
	When I press submit button
	Then my ip should be visible on the screen

Scenario: Get current location
	When I press submit button
	Then my location should be visible on the screen

Scenario: Get current location3
	When I press submit button
	Then my location should be visible on the screen

Scenario: Get current location4
	When I press submit button
	Then my location should be visible on the screen

Scenario: Button is enabled
	Then the I should be able to click on button
