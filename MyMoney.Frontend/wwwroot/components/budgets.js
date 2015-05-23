(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  myMoney.components.Budgets = React.createClass({displayName: "Budgets",
    render: function() {
      var items = [];

      this.props.items.forEach(function(budget) {
        items.push(React.createElement(myMoney.components.BudgetIndicator, {name: budget.name, max: budget.max, value: budget.amount}));
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
})(React);
