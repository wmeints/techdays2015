module.exports = {
  searchQuery: function() {
    return element(by.binding('vm.searchQuery')).getText();
  }
};
