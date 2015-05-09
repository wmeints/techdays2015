var BudgetIndicator = React.createClass({displayName: "BudgetIndicator",
  render: function() {
    return (
      React.createElement("div", {className: "budgetIndicator"}, 
        React.createElement(ProgressBar, {value: (100/this.props.max) * this.props.value}), 
        React.createElement("label", null, this.props.name, " - €", this.props.value, "( €", this.props.max, " )")
      )
    );
  }
});

//React.render(<BudgetIndicator/>, document.getElementById('budget-indicator'));
