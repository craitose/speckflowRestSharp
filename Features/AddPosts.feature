Feature: AddPosts
	

@mytag
Scenario: Add new posts
	Given I perform a post request
	And I input unique id title author
	When I send add post request
	Then valid post is created