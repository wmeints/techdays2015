'use strict';

describe('Service: storecatalog', function () {

  // load the service's module
  beforeEach(module('cloudyBooksApp'));

  // instantiate service
  var storecatalog;
  beforeEach(inject(function (_storecatalog_) {
    storecatalog = _storecatalog_;
  }));

  it('should do something', function () {
    expect(!!storecatalog).toBe(true);
  });

});
