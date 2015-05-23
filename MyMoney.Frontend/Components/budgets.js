(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  myMoney.components.Budgets = React.createClass({
    render: function() {
      var items = [];

      this.props.items.forEach(function(budget) {
        items.push(<myMoney.components.BudgetIndicator id={budget.id} name={budget.description} max={budget.maxAmountAvailable} value={budget.amountSpent} />);
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
})(React);
