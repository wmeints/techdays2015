(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  myMoney.components.BudgetStatus = React.createClass({displayName: "BudgetStatus",
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
        url: myMoney.settings.apiUrl + '/api/mutations/' + year + '/' + month,
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
        url: myMoney.settings.apiUrl + '/api/mutations/' + this.state.year + '/' + this.state.month,
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
      var totals = [];

      var totalEarned = 0.0;
      var totalSpent = 0.0;

      this.state.budgets.forEach(function(budget) {
        totalSpent += budget.amountSpent;
      });

      totals.push({ name: 'Earnings', value: totalEarned });
      totals.push({ name: 'Spendings', value: totalSpent });

      var result = totalEarned - totalSpent;

      return (
          React.createElement("div", {className: "budget-status"}, 
            React.createElement("div", {className: "row"}, 
              React.createElement("div", {className: "col-xs-12"}, 
                React.createElement("h1", null, "Budget status")
              )
            ), 
            React.createElement("div", {className: "row"}, 
              React.createElement("div", {className: "col-xs-12"}, 
                React.createElement("div", {className: "panel panel-default"}, 
                  React.createElement("div", {className: "panel-body"}, 
                    React.createElement("form", {className: "form-inline budget-state-selector", onSubmit: this.loadBudgetState}, 
                      React.createElement("div", {className: "form-group"}, 
                        React.createElement("label", {htmlFor: "year"}, "Year"), 
                        React.createElement("input", {type: "text", className: "form-control", name: "year", id: "year", value: this.state.year, onChange: this.yearChanged})
                      ), 
                      React.createElement("div", {className: "form-group"}, 
                        React.createElement("label", {htmlFor: "month"}, "Month"), 
                        React.createElement("input", {type: "text", className: "form-control", name: "month", id: "month", value: this.state.month, onChange: this.monthChanged})
                      ), 
                      React.createElement("div", {className: "form-group"}, 
                        React.createElement("button", {className: "btn btn-default", type: "submit"}, "Load")
                      )
                    )
                  )
                )
              )
            ), 
            React.createElement("div", {className: "row"}, 
              React.createElement("div", {className: "col-xs-12"}, 
                React.createElement(myMoney.components.Budgets, {items: this.state.budgets})
              )
            )
          )
      );
    }
  });

  var component = React.render(React.createElement(myMoney.components.BudgetStatus, null), document.getElementById('budget-status-placeholder'));

  myMoney.page = myMoney.page || {};
  myMoney.page.budgetState = component;
})(React);
