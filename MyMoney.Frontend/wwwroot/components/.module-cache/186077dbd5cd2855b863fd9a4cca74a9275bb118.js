var IncomeIndicator = React.createClass({displayName: "IncomeIndicator",
  render: function() {
    return (
      React.createElement("div", {key: this.props.id, className: "income-indicator"}, 
        React.createElement(ProgressBar, {value: (100/this.props.max) * this.props.value}), 
        React.createElement("label", null, this.props.name, " - €", this.props.value)
      )
    );
  }
});
