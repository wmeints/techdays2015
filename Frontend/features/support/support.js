function support() {
  this.World = function World(callback) {
    this.pageObjects = require('./pageobjects');

    callback();
  }
}

module.exports = support;
