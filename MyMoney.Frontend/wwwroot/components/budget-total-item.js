var BudgetTotalItem = React.createClass({displayName: "BudgetTotalItem",
  render: function() {
    return(
      React.createElement("div", {className: "row"}, 
          React.createElement("div", {className: "col-xs-12"}, 
              React.createElement("div", {className: "category-title"}, this.props.name), 
              React.createElement("div", {className: "category-value"}, "€ ", this.props.value)
          )
      )
    );
  }
});
