var assert = require('assert');

function steps() {
  this.When(/^I enter the search query '([^']*)'$/, function(queryText, callback) {
    var homepage = this.pageObjects.homepage;

    homepage.searchFor(queryText);
    callback();
  });

  this.Then(/^I see the search results for '([^']*)'$/, function(queryText, callback) {
    var searchpage = this.pageObjects.searchResults;

    searchpage.searchQuery().then(function(text) {
      assert(text.toLowerCase().trim().indexOf(queryText.toLowerCase().trim()));
      callback();
    });
  });
}

module.exports = steps;
