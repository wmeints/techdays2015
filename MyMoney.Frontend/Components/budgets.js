var Budgets = React.createClass({
  render: function() {
    var items = [];

    this.props.items.forEach(function(budget) {
      items.push(<BudgetIndicator id={budget.id} name={budget.description} max={budget.maxAmountAvailable} value={budget.amountSpent} />);
    }.bind(this));

    return (
      <div className="panel panel-default">
        <div className="panel-body">
          {items}
        </div>
      </div>
    );
  }
});
