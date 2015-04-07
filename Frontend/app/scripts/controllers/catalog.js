(function(angular) {
  'use strict';

  function CatalogCtrl(StoreCatalog) {
    var vm = this;

    vm.section = {
      title: '',
      name: ''
    };

    vm.browseTopTen = function() {
      //TODO: retrieve items from server
      vm.items = [];
      vm.section.title = 'Top 10 most popular books';
      vm.section.name = 'top-ten';
    };

    vm.browseAzure = function() {

      StoreCatalog.findByCategory('azure',0).then(function(result) {
        vm.items = result.data.items;
        vm.section.title = 'Azure books';
        vm.section.name = 'azure';
      });
    };

    vm.isActive = function(section) {
      return vm.section.name === section;
    };

    vm.browseTopTen();
  }

  CatalogCtrl.$inject = ['StoreCatalog'];

  angular.module('cloudyBooksApp').controller('CatalogCtrl', CatalogCtrl);
})(angular);
