(function(angular) {
  'use strict';

  function CatalogCtrl() {
    var vm = this;

    vm.section = {
      title: '',
      name: ''
    };

    vm.browseTopTen = function() {
      //TODO: retrieve items from server
      vm.section.title = 'Top 10 most popular books';
      vm.section.name = 'top-ten';
    };

    vm.browseAzure = function() {
      //TODO: Retrieve items from the server
      vm.section.title = 'Azure books';
      vm.section.name = 'azure';
    };

    vm.isActive = function(section) {
      return vm.section.name === section;
    };

    vm.browseTopTen();
  }

  CatalogCtrl.$inject = [];

  angular.module('cloudyBooksApp').controller('CatalogCtrl', CatalogCtrl);
})(angular);
