Feature: Homepage
    As a cloud fanatic
    I want to be able to see the latest offers on cloud books
    So that I can get more knowledge on cloud computing

Scenario: Visit homepage
    Given I am on the homepage
    Then I should see a "Catalog" link
    Then I should see a "Shopping cart" link
