(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  myMoney.components.BudgetIndicator = React.createClass({displayName: "BudgetIndicator",
    render: function() {
      var progressBarClasses = [];

      if(this.props.max >= this.props.value) {
        progressBarClasses.push('progress-bar-success');
      }

      if(this.props.max < this.props.value) {
        progressBarClasses.push('progress-bar-danger');
      }

      var progressValue = (100/this.props.max) * this.props.value;

      if(progressValue > 100) {
        progressValue = 100;
      }

      return (
        React.createElement("div", {key: this.props.id, className: "budget-indicator"}, 
          React.createElement(myMoney.components.ProgressBar, {value: progressValue, classes: progressBarClasses}), 
          React.createElement("label", null, this.props.name, ": €", this.props.value, " ( max €", this.props.max, " )")
        )
      );
    }
  });
})(React);
