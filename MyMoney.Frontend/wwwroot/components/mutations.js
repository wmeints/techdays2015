(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  myMoney.components.Mutations = React.createClass({displayName: "Mutations",
    getInitialState: function() {
      var currentDate = new Date();
      var year = currentDate.getFullYear();
      var month = currentDate.getMonth() + 1;

      return {
        year: 0,
        month: 0,
        mutations: [],
        categories: [],
        newMutation: {
          year: year,
          month: month,
          description: '',
          amount: null,
          category: null
        }
      };
    },
    componentDidMount: function() {
      var currentDate = new Date();
      var year = currentDate.getFullYear();
      var month = currentDate.getMonth() + 1;

      $.ajax({
        url: myMoney.settings.apiUrl + '/api/categories',
        success: function(data) {
            this.setState({
              categories: data
            });
        }.bind(this)
      });

      $.ajax({
        url: myMoney.settings.apiUrl + '/api/mutations/' + year + '/' + month,
        success: function(data) {
          this.setState({
            year: year,
            month: month,
            mutations: data
          });
        }.bind(this)
      });
    },
    categorySelected: function(evt) {
      this.setState({
        newMutation: {
          category: evt.target.value,
          year: this.state.newMutation && this.state.newMutation.year,
          month: this.state.newMutation && this.state.newMutation.month,
          description: this.state.newMutation && this.state.newMutation.description,
          amount: this.state.newMutation && this.state.newMutation.amount
        }
      });
    },
    mutationYearChanged: function(evt) {
      this.setState({
        newMutation: {
          category: this.state.newMutation && this.state.newMutation.category,
          year: evt.target.value,
          month: this.state.newMutation && this.state.newMutation.month,
          description: this.state.newMutation && this.state.newMutation.description,
          amount: this.state.newMutation && this.state.newMutation.amount
        }
      });
    },
    mutationMonthChanged: function(evt) {
      this.setState({
        newMutation: {
          category: this.state.newMutation && this.state.newMutation.category,
          year: this.state.newMutation && this.state.newMutation.year,
          month: evt.target.value,
          description: this.state.newMutation && this.state.newMutation.description,
          amount: this.state.newMutation && this.state.newMutation.amount
        }
      });
    },
    mutationDescriptionChanged: function(evt) {
      this.setState({
        newMutation: {
          category: this.state.newMutation && this.state.newMutation.category,
          year: this.state.newMutation && this.state.newMutation.year,
          month: this.state.newMutation && this.state.newMutation.month,
          description: evt.target.value,
          amount: this.state.newMutation && this.state.newMutation.amount
        }
      });
    },
    mutationAmountChanged: function(evt) {
      this.setState({
        newMutation: {
          category: this.state.newMutation && this.state.newMutation.category,
          year: this.state.newMutation && this.state.newMutation.year,
          month: this.state.newMutation && this.state.newMutation.month,
          description: this.state.newMutation && this.state.newMutation.description,
          amount: evt.target.value
        }
      });
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
    saveMutation: function(evt) {
      evt.preventDefault();

      var self = this;

      $.ajax({
        url: myMoney.settings.apiUrl + '/api/mutations/' + this.state.newMutation.year + '/' + this.state.newMutation.month,
        method: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify({
          category: this.state.newMutation.category,
          description: this.state.newMutation.description,
          amount: this.state.newMutation.amount
        }),
        success: function() {
          $.ajax({
            url: myMoney.settings.apiUrl + '/api/mutations/' + self.state.newMutation.year + '/' + self.state.newMutation.month,
            method: 'GET',
            success: function(data) {
              self.setState({
                mutations: data,
                year: self.state.newMutation.year,
                month: self.state.newMutation.month,
                newMutation: {
                  description: '',
                  amount: 0,
                  year: self.state.year,
                  month: self.state.month,
                  category: null
                }
              });
            }
          });
        }
      });

      return false;
    },
    loadMutations: function(evt) {
      evt.preventDefault();

      $.ajax({
        url: myMoney.settings.apiUrl + '/api/mutations/' + this.state.year + '/' + this.state.month,
        method: 'GET',
        success: function(data) {
          this.setState({
            mutations: data
          });
        }.bind(this)
      });

      return false;
    },
    render: function() {
      var categories = [];
      var mutations = [];

      categories.push(React.createElement("option", {value: ""}, "-"));

      for(var i = 0; i < this.state.categories.length; i++) {
        categories.push(React.createElement("option", {value: this.state.categories[i].id}, this.state.categories[i].name));
      }

      for(var j = 0; j < this.state.mutations.length; j++) {
        mutations.push(
          React.createElement("tr", null, 
            React.createElement("td", null, this.state.mutations[j].category.name), 
            React.createElement("td", null, this.state.mutations[j].description), 
            React.createElement("td", null, this.state.mutations[j].amount)
          )
        );
      }

      var mutationSearchResults = React.createElement("div", {className: "text-muted"}, "Sorry, there are not mutations for the given year/month combination");

      if(mutations.length > 0) {
        mutationSearchResults = React.createElement("table", {className: "table"}, 
          React.createElement("thead", null, 
            React.createElement("th", null, "Category"), 
            React.createElement("th", null, "Description"), 
            React.createElement("th", null, "Amount")
          ), 
          React.createElement("tbody", null, 
            mutations
          )
        );
      }

      return (
        React.createElement("div", {className: "mutations"}, 
          React.createElement("div", {className: "row"}, 
            React.createElement("div", {className: "col-xs-12"}, 
              React.createElement("h1", null, "Mutations")
            )
          ), 
          React.createElement("div", {className: "row"}, 
            React.createElement("div", {className: "col-xs-12"}, 
              React.createElement("div", {className: "panel panel-default"}, 
                React.createElement("div", {className: "panel-body"}, 
                  React.createElement("form", {className: "form-inline enter-mutation-form", onSubmit: this.saveMutation}, 
                    React.createElement("div", {className: "form-group"}, 
                      React.createElement("label", {htmlFor: "budget", className: "sr-only"}, "Budget"), 
                      React.createElement("select", {className: "form-control", id: "budget", onChange: this.categorySelected}, 
                        categories
                      )
                    ), 
                    React.createElement("div", {className: "form-group"}, 
                      React.createElement("label", {htmlFor: "text", className: "sr-only"}, "Year"), 
                      React.createElement("input", {type: "text", className: "form-control", id: "year", autocomplete: "off", placeholder: "Enter year", value: this.state.newMutation.year, onChange: this.mutationYearChanged})
                    ), 
                    React.createElement("div", {className: "form-group"}, 
                      React.createElement("label", {htmlFor: "month", className: "sr-only"}, "Month"), 
                      React.createElement("input", {type: "text", className: "form-control", id: "month", autocomplete: "off", placeholder: "Enter month", value: this.state.newMutation.month, onChange: this.mutationMonthChanged})
                    ), 
                    React.createElement("div", {className: "form-group"}, 
                      React.createElement("label", {htmlFor: "description", className: "sr-only"}, "Description"), 
                      React.createElement("input", {type: "text", className: "form-control", id: "description", autocomplete: "off", placeholder: "Enter description", value: this.state.newMutation.description, onChange: this.mutationDescriptionChanged})
                    ), 
                    React.createElement("div", {className: "form-group"}, 
                      React.createElement("label", {htmlFor: "amount", className: "sr-only"}, "Amount"), 
                      React.createElement("input", {type: "text", className: "form-control", id: "amount", placeholder: "Enter amount", autocomplete: "false", value: this.state.newMutation.amount, onChange: this.mutationAmountChanged})
                    ), 
                    React.createElement("button", {type: "submit", className: "btn btn-default"}, "Save")
                  )
                )
              )
            )
          ), 
          React.createElement("div", {className: "row"}, 
            React.createElement("div", {className: "col-xs-12"}, 
              React.createElement("form", {className: "form-inline mutations-state-selector", onSubmit: this.loadMutations}, 
                React.createElement("div", {className: "form-group"}, 
                  React.createElement("label", {htmlFor: "year"}, "Year"), 
                  React.createElement("input", {type: "text", className: "form-control", name: "year", id: "year", autocomplete: "off", value: this.state.year, onChange: this.yearChanged})
                ), 
                React.createElement("div", {className: "form-group"}, 
                  React.createElement("label", {htmlFor: "month"}, "Month"), 
                  React.createElement("input", {type: "text", className: "form-control", name: "month", id: "month", autocomplete: "off", value: this.state.month, onChange: this.monthChanged})
                ), 
                React.createElement("div", {className: "form-group"}, 
                  React.createElement("button", {className: "btn btn-default", type: "submit"}, "Load")
                )
              )
            )
          ), 
          React.createElement("div", {className: "row"}, 
            React.createElement("div", {className: "col-xs-12"}, 
              React.createElement("div", {className: "panel panel-default enter-mutation-form"}, 
                React.createElement("div", {className: "panel-body"}, 
                  mutationSearchResults
                )
              )
            )
          )
        )
      );
    }
  });

  var component = React.render(React.createElement(myMoney.components.Mutations, null), document.getElementById('mutations-placeholder'));

  //HACK: Disable autocomplete for all components.
  //It's annoying for the demo, but there's no good way to disable it through React.
  $('input').attr('autocomplete','off');

  myMoney.page = myMoney.page || {};
  myMoney.page.mutations = component;
})(React);
