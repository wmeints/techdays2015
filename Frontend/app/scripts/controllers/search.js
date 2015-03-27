'use strict';

function SearchCtrl($routeParams) {
    var vm = this;

    vm.searchQuery = $routeParams.query;
}

SearchCtrl.$inject = ['$routeParams'];

angular.module('cloudyBooksApp').controller('SearchCtrl',SearchCtrl);
