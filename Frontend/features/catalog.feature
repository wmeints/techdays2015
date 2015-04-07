Feature: Catalog
  As a customer
  I want to be able to browse the catalog
  In order to see what books on cloud technology there are

Scenario: Browse top 10
  Given I am browsing the catalog
  When I select top 10
  Then I see the top 10 books

Scenario: Browse azure books
  Given I am browsing the catalog
  When I select azure
  Then I see the azure books
