'use strict';

/**
 * @ngdoc overview
 * @name cloudyBooksApp
 * @description
 * # cloudyBooksApp
 *
 * Main module of the application.
 */
angular
  .module('cloudyBooksApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl',
        controllerAs: 'vm'
      })
      .when('/catalog', {
        templateUrl: 'views/catalog.html',
        controller: 'CatalogCtrl',
        controllerAs: 'vm'
      })
      .when('/search', {
        templateUrl: 'views/search.html',
        controller: 'SearchCtrl',
        controllerAs: 'vm'
      })
      .when('/shopping-cart', {
        templateUrl: 'views/shoppingcart.html',
        controller: 'ShoppingCartCtrl',
        controllerAs: 'vm'
      })
      .when('/about', {
        templateUrl: 'views/about.html',
        controller: 'AboutCtrl',
        controllerAs: 'vm'
      })
      .otherwise({
        redirectTo: '/'
      });
  });
