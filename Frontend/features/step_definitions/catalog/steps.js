var assert = require('assert');

function steps() {
  this.Given(/^I am browsing the catalog$/, function (callback) {
    this.pageObjects.catalog.visit().then(callback);
  });

  this.When(/^I select top 10$/, function (callback) {
    this.pageObjects.catalog.selectTopTen().then(callback);
  });

  this.Then(/^I see the top 10 books$/, function (callback) {
    this.pageObjects.catalog.sectionTitle().then(function(text) {
      assert(text === 'Top 10 most popular books');
      callback();
    });
  });

  this.When(/^I select azure$/, function (callback) {
    this.pageObjects.catalog.selectAzure().then(callback);
  });

  this.Then(/^I see the azure books$/, function (callback) {
    this.pageObjects.catalog.sectionTitle().then(function(text) {
      assert(text === 'Azure books');
      callback();
    });
  });
}

module.exports = steps;
