'use strict';

describe('Controller: CatalogCtrl', function () {

  // load the controller's module
  beforeEach(module('cloudyBooksApp'));

  var CatalogCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    CatalogCtrl = $controller('CatalogCtrl', { });
  }));
});
