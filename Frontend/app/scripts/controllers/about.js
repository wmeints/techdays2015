'use strict';

/**
 * @ngdoc function
 * @name cloudyBooksApp.controller:AboutCtrl
 * @description
 * # AboutCtrl
 * Controller of the cloudyBooksApp
 */
angular.module('cloudyBooksApp')
  .controller('AboutCtrl', function ($scope) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  });
