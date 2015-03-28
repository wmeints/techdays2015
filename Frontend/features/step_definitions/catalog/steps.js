function steps() {
  this.Given(/^I am browsing the catalog$/, function (callback) {
    this.pageObjects.catalog.visit().then(callback);
  });

  this.When(/^I select top 10$/, function (callback) {
    // Write code here that turns the phrase above into concrete actions
    callback.pending();
  });

  this.Then(/^I see the top 10 books$/, function (callback) {
    // Write code here that turns the phrase above into concrete actions
    callback.pending();
  });

  this.When(/^I select by author$/, function (callback) {
    // Write code here that turns the phrase above into concrete actions
    callback.pending();
  });

  this.Then(/^I see the books sorted by author$/, function (callback) {
    // Write code here that turns the phrase above into concrete actions
    callback.pending();
  });

  this.When(/^I select by title$/, function (callback) {
    // Write code here that turns the phrase above into concrete actions
    callback.pending();
  });

  this.Then(/^I see the books sorted by title$/, function (callback) {
    // Write code here that turns the phrase above into concrete actions
    callback.pending();
  });
}

module.exports = steps;
