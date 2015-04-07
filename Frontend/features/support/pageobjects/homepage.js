module.exports = {
  searchFor: function searchFor(queryText) {
    element(by.id('search-form-query')).sendKeys(queryText);
    element(by.id('search-form-submit')).click();
  },
  visit: function() {
    return browser.get('#/');
  }
};
