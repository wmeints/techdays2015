var BudgetIndicator = React.createClass({displayName: "BudgetIndicator",
  render: function() {
    return (
      React.createElement("div", {className: "budgetIndicator"}, 
        React.createElement(ProgressBar, {value: (100/this.props.maxAmountAvailable) * this.props.amountSpent}), 
        React.createElement("label", null, this.props.name, " - ", this.props.amountSpent, "(", this.props.maxAmountAvailable, ")")
      )
    );
  }
});

//React.render(<BudgetIndicator/>, document.getElementById('budget-indicator'));