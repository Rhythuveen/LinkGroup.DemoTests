Feature: Link Fund Solutions
	Test suite tests the Fund solutions page and links

@mytag
Scenario Outline: Jurisdiction
When i open the Fund Solutions page
Then i can select the <Jurisdiction name> Jurisdiction
Examples: 
| Jurisdiction name |
| United Kingdom    |
| Switzerland       |