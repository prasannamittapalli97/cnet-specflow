Feature: AddLowestPriceItemToCart

@addItem
Scenario: Add Lowest price item from different products in wishlist and verify the item in cart
	Given I add four different products to my wish list
	When I view my wishlist table
	Then I find total four selected items in my Wishlist
	When I add first item in add to cart
	Then I am able to verify the item in my cart