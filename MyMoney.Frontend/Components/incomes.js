var Incomes = React.createClass({
  render: function() {
    var items = [];
    var totalIncome = 0.0;

    this.props.items.forEach(function(income) {
      totalIncome += income.amount;
    });

    this.props.items.forEach(function(income) {
      items.push(<IncomeIndicator id={income.id} name={income.description} value={income.amount} max={totalIncome} />);
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

// var BUDGETS = [ { id: 1, description: 'Hypotheek', maxAmountAvailable: 850, amountSpent: 650 }];
//
// React.render(<Budgets budgets={BUDGETS}/>, document.getElementById('budgets'));
