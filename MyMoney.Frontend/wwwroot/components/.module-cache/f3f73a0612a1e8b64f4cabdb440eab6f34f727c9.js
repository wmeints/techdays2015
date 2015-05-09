var BudgetTotal = React.createClass({displayName: "BudgetTotal",
  render: function() {
    var items = [];

    this.props.items.forEach(function(item) {
      items.push(React.createElement(BudgetTotalItem, {value: item.value, name: item.description}));
    }.bind(this));

    return (
      React.createElement("div", {className: "panel panel-default totals"}, 
          React.createElement("div", {className: "panel-body"}, 
              items
          )
      )
    );
  }
});
