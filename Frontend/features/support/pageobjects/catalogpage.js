module.exports = {
  visit: function() {
    return browser.get('#/catalog');
  },
  selectTopTen: function() {
    return element(by.id('browse-top-ten')).click();
  },
  selectAzure: function() {
    return element(by.id('browse-azure')).click();
  },
  sectionTitle: function() {
    return element(by.binding('vm.section.title')).getText();
  }
};
