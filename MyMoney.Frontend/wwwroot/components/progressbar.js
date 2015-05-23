(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  myMoney.components.ProgressBar = React.createClass({displayName: "ProgressBar",
    render: function() {
      var progressBarClasses = ['progress-bar'];

      if(this.props.classes) {
        this.props.classes.forEach(function(item) {
          progressBarClasses.push(item);
        });
      }

      return (
        React.createElement("div", {className: "progress"}, 
          React.createElement("div", {className: progressBarClasses.join(' '), style: {width: this.props.value + '%'}})
        )
      );
    }
  });
})(React);
