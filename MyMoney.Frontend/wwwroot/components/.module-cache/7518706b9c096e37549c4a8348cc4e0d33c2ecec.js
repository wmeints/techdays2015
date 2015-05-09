var BudgetIndicator = React.createClass({displayName: "BudgetIndicator",
  render: function() {
    return (
      React.createElement("div", {className: "budgetIndicator"}, 
        React.createElement(ProgressBar, null), 
        React.createElement("label", null, this.props.name, " - ", this.props.amountSpent, "(", this.props.maxAmountAvailable, ")")
      )
    );
  }
});

//React.render(<BudgetIndicator/>, document.getElementById('budget-indicator'));
