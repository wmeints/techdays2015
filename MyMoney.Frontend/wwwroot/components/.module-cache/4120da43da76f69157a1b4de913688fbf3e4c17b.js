var BudgetIndicator = React.createClass({displayName: "BudgetIndicator",
  render: function() {
    return (
      React.createElement("div", {key: this.props.id, className: "budgetIndicator"}, 
        React.createElement(ProgressBar, {value: (100/this.props.max) * this.props.value}), 
        React.createElement("label", null, this.props.name, " - €", this.props.value, " ( €", this.props.max, " )")
      )
    );
  }
});
