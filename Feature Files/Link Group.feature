Feature: Link Group
	Test suite tests the Link Home page and search functionality

@mytag
Scenario: Smoke Test
	When I open the home page
	Then the page is displayed


Scenario: Search Results
	Given I have opened the home page
	And i have agreed to the cookie policy
	When i search for Leeds
	Then the search results are displayed
	


