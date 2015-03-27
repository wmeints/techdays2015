(function(angular) {
  'use strict';

  function SearchFormCtrl($location) {
    var vm = this;

    vm.searchQuery = '';
    vm.search = function() {
      $location.path('/search').search({ query: vm.searchQuery });
    };
  }

  SearchFormCtrl.$inject = ['$location'];

  angular.module('cloudyBooksApp').controller('SearchFormCtrl',SearchFormCtrl);  
})(angular);
