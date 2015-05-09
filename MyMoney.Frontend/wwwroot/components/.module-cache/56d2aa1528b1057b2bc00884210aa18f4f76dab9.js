var BudgetIndicator = React.createClass({displayName: "BudgetIndicator",
  render: function() {
    return (
      React.createElement("div", {className: "budgetIndicator"}, 
        "Hello!"
      )
    );
  }
});

React.render(React.createElement(BudgetIndicator, null), document.getElementById('budget-indicator'));
