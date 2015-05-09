var BudgetStatus = React.createClass({displayName: "BudgetStatus",
  render: function() {
    return (
        React.createElement("div", {className: "budget-status"}, 
          React.createElement("div", {className: "row"}, 
              React.createElement("div", {className: "col-xs-12"}, 
                  React.createElement("h1", null, "Budget status")
              )
          ), 

          React.createElement("div", {className: "row"}, 
            React.createElement("div", {className: "col-xs-9"}, 
              React.createElement("div", {className: "row"}, 
                React.createElement("div", {className: "col-xs-12"}, 
                  React.createElement("h2", null, "Income"), 
                  React.createElement(Incomes, {items: incomes})
                )
              ), 
              React.createElement("div", {className: "row"}, 
                React.createElement("div", {className: "col-xs-12"}, 
                  React.createElement("h2", null, "Budgets"), 
                  React.createElement(Budgets, {items: budgets})
                )
              )
            ), 
            React.createElement("div", {className: "col-xs-3"}, 
              React.createElement("h2", null, "Total"), 
              React.createElement(BudgetTotal, {items: totals})
            )
          )
        )
    );
  }
});
