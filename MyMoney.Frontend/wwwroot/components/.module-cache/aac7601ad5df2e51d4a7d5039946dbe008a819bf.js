var BudgetTotal = React.createClass({displayName: "BudgetTotal",
  render: function() {
    var items = [];

    this.props.items.forEach(function(item) {
      items.push(React.createElement(BudgetTotalItem, {value: item.value, description: item.description}));
    });

    return (
      React.createElement("div", {class: "panel panel-default totals"}, 
          React.createElement("div", {class: "panel-body"}, 
              items
          )
      )
    );
  }
});
