Feature: DeletePost
	Simple calculator for adding two numbers

@mytag
Scenario: Delete a post
	Given I perform a delete request
	And I input target post id
	When I send a delete request
	Then the post is removed from list