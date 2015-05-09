var BudgetIndicator = React.createClass({displayName: "BudgetIndicator",
  render: function() {
    return (
      React.createElement("div", {className: "budgetIndicator"}, 
        React.createElement(ProgressBar, null)
        
      )
    );
  }
});

//React.render(<BudgetIndicator/>, document.getElementById('budget-indicator'));
