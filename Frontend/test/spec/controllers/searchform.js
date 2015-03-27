'use strict';

describe('Controller: SearchformCtrl', function () {

  // load the controller's module
  beforeEach(module('cloudyBooksApp'));

  var SearchformCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    SearchformCtrl = $controller('SearchformCtrl', {
      $scope: scope
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(scope.awesomeThings.length).toBe(3);
  });
});
