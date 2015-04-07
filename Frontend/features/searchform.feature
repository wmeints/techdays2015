Feature: Search form
  As a customer
  I want to be able to search for books
  So that I can find some awesome books on cloud tech

Scenario Outline: Enter search query
  Given I am on the homepage
  When I enter the search query '<query>'
  Then I see the search results for '<query>'

Examples:

| query             |
| Azure for dummies |
