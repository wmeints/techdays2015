var BudgetIndicator = React.createClass({displayName: "BudgetIndicator",
  render: function() {
    return (
      React.createElement("div", {className: "budgetIndicator"}, 
        React.createElement("div", {class: "progress"}, 
          React.createElement("div", {class: "progress-bar progress-bar-success", role: "progressbar", "aria-valuenow": "75", "aria-valuemin": "0", "aria-valuemax": "100", style: "width: 75%;"}

          )
        ), 
        React.createElement("label", null, "Verzekeringen - €300 (max: €400)")
      )
    );
  }
});

React.render(React.createElement(BudgetIndicator, null), document.getElementById('budget-indicator'));
