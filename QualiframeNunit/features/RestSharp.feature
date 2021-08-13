
Feature: RestSharp API Tests

@RestSharp
Scenario: 1 Create User
 	Given I have endpoint users with create user payload
 	When I create user
    Then verify the user is created successfully

@RestSharp
Scenario: 2 Get User
 	Given I have an endpoint users?page=2
 	When I call get users
    Then verify the user data returned successfully

Scenario: 4 Delete User
 	Given I have an endpoint users/2
 	When I call delete users
    Then verify the user has been deleted successfully

Scenario: 3 Update User
 	Given I have endpoint users with update user payload
 	When I call put users
    Then verify the user has been updated successfully