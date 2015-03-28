var assert = require('assert');

var steps = function() {
  this.Given(/^I am on the homepage$/, function(callback) {
    var homepage = this.pageObjects.homepage;
    homepage.visit().then(callback);
  });

  this.Then(/^I should see a "([^"]*)" link$/, function(link, callback) {
    browser.findElement(by.cssContainingText('.nav-item', link)).then(function(result) {
      assert(result !== null);

      result.getText().then(function(text) {
        assert(text.trim().toLowerCase() === link.trim().toLowerCase())
        callback();
      });
    });
  });
};

module.exports = steps;
