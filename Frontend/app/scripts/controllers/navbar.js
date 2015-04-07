(function(angular) {
  'use strict';

  function NavbarCtrl($location) {
    var vm = this;

    vm.isActive = function(location) {
      return location === $location.path();
    };
  }

  NavbarCtrl.$inject = ['$location'];

  angular.module('cloudyBooksApp').controller('NavbarCtrl', NavbarCtrl);  
})(angular);
