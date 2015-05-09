var BudgetIndicator = React.createClass({displayName: "BudgetIndicator",
  render: function() {
    var progressBarClasses = [];

    if(this.props.max >= this.props.value) {
      progressBarClasses.push('progress-bar-success');
    }

    if(this.props.max < this.props.value) {
      progressBarClasses.push('progress-bar-error');
    }

    return (
      React.createElement("div", {key: this.props.id, className: "budgetIndicator"}, 
        React.createElement(ProgressBar, {value: (100/this.props.max) * this.props.value, classes: progressBarClasses}), 
        React.createElement("label", null, this.props.name, ": €", this.props.value, " ( €", this.props.max, " )")
      )
    );
  }
});
