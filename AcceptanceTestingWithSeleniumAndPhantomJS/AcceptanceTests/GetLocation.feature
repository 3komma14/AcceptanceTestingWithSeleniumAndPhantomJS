﻿Feature: GetLocation
	In order to avoid silly mistakes
	As a user
	I want to know my current location

Scenario: Get current location
	Given I have opened the webpage
	When I press submit button
	Then my location should be visible on the screen