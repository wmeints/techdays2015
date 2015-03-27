'use strict';

/**
 * @ngdoc function
 * @name cloudyBooksApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the cloudyBooksApp
 */
angular.module('cloudyBooksApp')
  .controller('MainCtrl', function ($scope) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  });
