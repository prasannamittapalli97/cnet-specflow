@order
Feature: order tshirt
  Scenario: verify order confirmation in order history page
    Given I am on homepage
    When I sign in with <UserName> <Password>
    And I order a tshirt
    Then I should see my order in order history
    
    Examples: 
      | UserName | Password | 
      | testuser03@gmail.com      | qualitest    |

  Scenario: update personal information
    Given I am on homepage
    When I sign in with <UserName> <Password>
    And I update my personal information
    Then my personal information is saved
    
    Examples: 
      | UserName | Password | 
      | testuser03@gmail.com      | qualitest    |    
    

    