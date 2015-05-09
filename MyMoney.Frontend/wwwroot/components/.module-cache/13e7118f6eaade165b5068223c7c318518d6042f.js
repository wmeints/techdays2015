var BudgetTotal = React.createClass({displayName: "BudgetTotal",
  render: function() {
    var items = [];

    this.props.items.forEach(function(item) {
      items.push(React.createElement(BudgetTotalItem, {value: item.value, name: item.name}));
    }.bind(this));

    return (
      React.createElement("div", {className: "panel panel-default totals"}, 
          React.createElement("div", {className: "panel-body"}, 
              items, 

              React.createElement("div", {className: "row"}, 
                React.createElement("div", {className: "col-xs-12"}, 
                  React.createElement("hr", null)
                )
              ), 
              React.createElement("div", {className: "row"}, 
                React.createElement("div", {className: "col-xs-12"}, 
                  React.createElement("div", {className: "pull-right"}, 
                    "€ ", this.props.result
                  )
                )
              )
          )
      )
    );
  }
});
