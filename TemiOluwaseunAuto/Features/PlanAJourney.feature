Feature: JourneyPlanner

This is to verify that the Journey planner widget works as per Acceptance Criteria
Background: 
	Given I navigate to Journey planner Page on TFL
	

Scenario: Verify Valid Journey on Journey Planner
	And I enter valid location "DA8 2AG" into From Field
	And I enter valid location "SW1P 4NP" into To Field
	When I click Plan a Journey Button
	Then Journey Results should be displayed
	

Scenario: Verify Invalid Journey on Journey Planner
	And I enter invalid location "da55 1qw" into From Field
	And I enter invalid location "da88 1rt" into To Field
	When I click Plan a Journey Button
	Then No Journey Results should be displayed
	

Scenario: Verify No Journeys Planned for Nulls on Locations
	When  I click Plan a Journey Button without filling To and From Field
	Then field level validation errors should be displayed

Scenario: Verify User can Edit Journeys on Journey Results Page
	And I enter valid location "DA8 2AG" into From Field
	And I enter valid location "SW1P 4NP" into To Field
	And I click Plan a Journey Button
	When I click on Edit Journey Button
	And I Edit the To field to "SW6 4QA"
	And I click Update Journey Button
	Then Journey Results should be updated

Scenario: Verify Recents Tab displays list of recently planned Journeys
	And I have planned several valid Journeys 
	When I navigate to the Recent Tab
	Then I should be able to see the list of All Journeys Planned