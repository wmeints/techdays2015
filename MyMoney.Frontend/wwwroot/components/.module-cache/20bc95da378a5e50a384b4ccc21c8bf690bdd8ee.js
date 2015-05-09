var Budgets = React.createClass({displayName: "Budgets",
  render: function() {
    var items = [];

    props.budgets.forEach(function(budget) {
      items.push(React.createElement(BudgetIndicator, {name: budget.description, max: budget.maxAmountAvailable, value: budget.amountSpent}));
    }).bind(this);

    return (
      React.createElement("div", {className: "panel panel-default"}, 
        React.createElement("div", {className: "panel-body"}, 
          items
        )
      )
    );
  }
});
