Feature: GetLocation
	In order to avoid silly mistakes
	As a user
	I want to know my current location

Scenario: Get current ip address
	Given I have opened the webpage
	When I press submit button
	Then my ip should be visible on the screen

Scenario: Get current location
	Given I have opened the webpage
	When I press submit button
	Then my location should be visible on the screen

Scenario: Get current location3
	Given I have opened the webpage
	When I press submit button
	Then my location should be visible on the screen

Scenario: Get current location4
	Given I have opened the webpage
	When I press submit button
	Then my location should be visible on the screen

Scenario: Button is enabled
	Given I have opened the webpage
	Then the I should be able to click on button
