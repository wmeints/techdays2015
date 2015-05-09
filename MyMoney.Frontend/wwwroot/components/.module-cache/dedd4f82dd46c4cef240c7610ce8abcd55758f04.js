var Incomes = React.createClass({displayName: "Incomes",
  render: function() {
    var items = [];

    this.props.items.forEach(function(budget) {
      items.push(React.createElement(IncomeIndicator, {name: budget.description, max: budget.maxAmountAvailable, value: budget.amountSpent}));
    }.bind(this));

    return (
      React.createElement("div", {className: "panel panel-default"}, 
        React.createElement("div", {className: "panel-body"}, 
          items
        )
      )
    );
  }
});

// var BUDGETS = [ { id: 1, description: 'Hypotheek', maxAmountAvailable: 850, amountSpent: 650 }];
//
// React.render(<Budgets budgets={BUDGETS}/>, document.getElementById('budgets'));
