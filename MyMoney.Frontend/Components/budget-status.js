(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  myMoney.components.BudgetStatus = React.createClass({
    getInitialState: function() {
      return {
        budgets: []
      }
    },
    componentDidMount: function() {
      var currentDate = new Date();
      var year = currentDate.getFullYear();
      var month = currentDate.getMonth() + 1;

      this.setState({
        year: year,
        month: month,
        budgets: []
      });

      //TODO: Refactor this into a service
      $.ajax({
        url: myMoney.settings.apiUrl + '/api/state/' + year + '/' + month,
        success: function(data) {
          this.setState({
            year: year,
            month: month,
            budgets: data
          });
        }.bind(this)
      });
    },
    loadBudgetState: function() {
      //TODO: Refactor this into a service
      $.ajax({
        url: myMoney.settings.apiUrl + '/api/state/' + this.state.year + '/' + this.state.month,
        success: function(data) {
          this.setState({
            budgets: data
          });
        }.bind(this)
      });

      return false;
    },
    yearChanged: function(evt) {
      this.setState({
        year: evt.target.value
      });
    },
    monthChanged: function(evt) {
      this.setState({
        month: evt.target.value
      });
    },
    render: function() {
      return (
          <div className="budget-status">
            <div className="row">
              <div className="col-xs-12">
                <h1>Budget status</h1>
              </div>
            </div>
            <div className="row">
              <div className="col-xs-12">
                <div className="panel panel-default">
                  <div className="panel-body">
                    <form className="form-inline budget-state-selector" onSubmit={this.loadBudgetState}>
                      <div className="form-group">
                        <label htmlFor="year">Year</label>
                        <input type="text" className="form-control" name="year" id="year" value={this.state.year} onChange={this.yearChanged} />
                      </div>
                      <div className="form-group">
                        <label htmlFor="month">Month</label>
                        <input type="text" className="form-control" name="month" id="month" value={this.state.month} onChange={this.monthChanged} />
                      </div>
                      <div className="form-group">
                        <button className="btn btn-default" type="submit">Load</button>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col-xs-12">
                <myMoney.components.Budgets items={this.state.budgets}/>
              </div>
            </div>
          </div>
      );
    }
  });

  var component = React.render(<myMoney.components.BudgetStatus/>, document.getElementById('budget-status-placeholder'));

  myMoney.page = myMoney.page || {};
  myMoney.page.budgetState = component;
})(React);
