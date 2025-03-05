Feature: Web Maps Navigation
  As a user
  I want to navigate using Google Maps in a browser
  So that I can find directions to my destination

  Scenario: Navigate from London Bridge to Solirius Office on Web
    Given I have opened Google Maps in a browser
    When I enter "London Bridge" as the starting point
    And I enter "65-68 Leadenhall Street, EC3A 2AD" as the destination
    Then I should see directions to the Solirius Office