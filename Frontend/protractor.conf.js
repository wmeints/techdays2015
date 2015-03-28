exports.config = {
  // The address of a running selenium server.
  seleniumAddress: 'http://localhost:4444/wd/hub',

  // Spec patterns are relative to the location of this config.
  specs: [
    'features/**/*.feature'
  ],


  capabilities: {
    'browserName': 'chrome',
    'chromeOptions': {'args': ['--disable-extensions']}
  },


  // A base URL for your application under test. Calls to protractor.get()
  // with relative paths will be prepended with this.
  baseUrl: 'http://localhost:9000',

  // Use cucumber to write the tests
  framework: 'cucumber',

  cucumberOpts: {
    require: ['features/step_definitions/**/steps.js', 'features/support/*.js'],
    format: 'progress'
  }
};
