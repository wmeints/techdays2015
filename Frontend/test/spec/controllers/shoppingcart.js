'use strict';

describe('Controller: ShoppingcartCtrl', function () {

  // load the controller's module
  beforeEach(module('cloudyBooksApp'));

  var ShoppingcartCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    ShoppingcartCtrl = $controller('ShoppingcartCtrl', {});
  }));
});
