function steps() {
  this.Given(/^I am browsing the catalog$/, function (callback) {
    this.pageObjects.catalog.visit().then(callback);
  });
}

module.exports = steps;
