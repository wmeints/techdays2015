var Incomes = React.createClass({displayName: "Incomes",
  render: function() {
    var items = [];

    this.props.items.forEach(function(income) {
      items.push(React.createElement(IncomeIndicator, {id: income.id, name: income.description, value: income.amount}));
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
