(function(angular) {
  'use strict';

  function StoreCatalog($http) {
    function findByCategory(category, pageIndex) {
      return $http.get('http://localhost:3001/api/books/category/' + category + '?pageIndex=' + (pageIndex || 0));
    }

    return {
      findByCategory: findByCategory
    };
  }

  StoreCatalog.$inject = ['$http'];

  angular.module('cloudyBooksApp').factory('StoreCatalog', StoreCatalog);
})(angular);
