Feature: Catalog
  As a customer
  I want to be able to browse the catalog
  In order to see what books on cloud technology there are

Scenario: Browse top 10
  Given I am browsing the catalog
  When I select top 10
  Then I see the top 10 books

Scenario: Browse by author
  Given I am browsing the catalog
  When I select by author
  Then I see the books sorted by author

Scenario: Browse by title
  Given I am browsing the catalog
  When I select by title
  Then I see the books sorted by title
