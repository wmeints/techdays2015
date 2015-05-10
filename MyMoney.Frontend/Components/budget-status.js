var BudgetStatus = React.createClass({
  render: function() {
    var totals = [];

    var totalEarned = 0.0;
    var totalSpent = 0.0;

    this.props.incomes.forEach(function(income) {
      totalEarned += income.amount;
    });

    this.props.budgets.forEach(function(budget) {
      totalSpent += budget.amountSpent;
    });

    totals.push({ name: 'Earnings', value: totalEarned });
    totals.push({ name: 'Spendings', value: totalSpent });

    var result = totalEarned - totalSpent;

    return (
        <div className="budget-status">
          <div class="row">
            <div class="col-xs-12">
              <h1>Budget status</h1>
            </div>
          </div>
          <div className="row">
            <div className="col-xs-9">
              <div className="row">
                <div className="col-xs-12">
                  <h2>Income</h2>
                  <Incomes items={this.props.incomes}/>
                </div>
              </div>
              <div className="row">
                <div className="col-xs-12">
                  <h2>Budgets</h2>
                  <Budgets items={this.props.budgets}/>
                </div>
              </div>
            </div>
            <div className="col-xs-3">
              <h2>Total</h2>
              <BudgetTotal items={totals} result={result}/>
            </div>
          </div>
        </div>
    );
  }
});

var BUDGETS = [
  { id: 1, description: 'Hypotheek', maxAmountAvailable: 850, amountSpent: 650 },
  { id: 3, description: 'Verzekeringen', maxAmountAvailable: 400, amountSpent: 114 },
  { id: 4, description: 'Uit eten', maxAmountAvailable: 50, amountSpent: 120 }
];
var INCOMES = [
  { id: 2, description: 'Loon Mike', amount: 4035 },
  { id: 5, description: 'Loon Barbara', amount: 1500 },
  { id: 6, description: 'Overige', amount: 250 }
];

React.render(<BudgetStatus incomes={INCOMES} budgets={BUDGETS}/>, document.getElementById('budget-status-placeholder'));
