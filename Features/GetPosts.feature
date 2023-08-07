Feature: GetPosts
	

@mytag
Scenario: Get all posts
	Given I perform a get request
	When I send a get request
	Then the first post is valid