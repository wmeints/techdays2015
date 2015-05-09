var BudgetStatus = React.createClass({displayName: "BudgetStatus",
  render: function() {
    var totals = [];

    var totalEarned = 0.0;
    var totalSpent = 0.0;

    this.props.incomes.forEach(function(income) {
      totalEarned += income.amount;
    });

    this.props.budgets.forEach(function(budget) {
      totalSpent += budget.amountSpent;
    });

    totals.push({ name: 'Earnings', value: totalEarned });
    totals.push({ name: 'Spendings', value: totalSpent });

    var result = totalEarned - totalSpent;

    return (
        React.createElement("div", {className: "budget-status"}, 
          React.createElement("div", {className: "row"}, 
            React.createElement("div", {className: "col-xs-9"}, 
              React.createElement("div", {className: "row"}, 
                React.createElement("div", {className: "col-xs-12"}, 
                  React.createElement("h2", null, "Income"), 
                  React.createElement(Incomes, {items: this.props.incomes})
                )
              ), 
              React.createElement("div", {className: "row"}, 
                React.createElement("div", {className: "col-xs-12"}, 
                  React.createElement("h2", null, "Budgets"), 
                  React.createElement(Budgets, {items: this.props.budgets})
                )
              )
            ), 
            React.createElement("div", {className: "col-xs-3"}, 
              React.createElement("h2", null, "Total"), 
              React.createElement(BudgetTotal, {items: totals, result: result})
            )
          )
        )
    );
  }
});

var BUDGETS = [ { id: 1, description: 'Hypotheek', maxAmountAvailable: 850, amountSpent: 650 }];
var INCOMES = [ { id: 2, description: 'Loon Mike', amount: 4035 }];

React.render(React.createElement(BudgetStatus, {incomes: INCOMES, budgets: BUDGETS}), document.getElementById('budget-status-placeholder'));
