(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  myMoney.components.Mutations = React.createClass({displayName: "Mutations",
    getInitialState: function() {


      return {
        year: 0,
        month: 0,
        mutations: []
      };
    },
    componentDidMount: function() {
      var currentDate = new Date();
      var year = currentDate.getFullYear();
      var month = currentDate.getMonth() + 1;

      this.setState({
        year: year,
        month: month
      });
    },
    render: function() {
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
                  React.createElement("form", {className: "form-inline enter-mutation-form"}, 
                    React.createElement("div", {className: "form-group"}, 
                      React.createElement("label", {htmlFor: "budget", className: "sr-only"}, "Budget"), 
                      React.createElement("select", {className: "form-control", id: "budget"}, 
                        React.createElement("option", null, "-"), 
                        React.createElement("option", {value: "1"}, "Huis"), 
                        React.createElement("option", {value: "2"}, "Energie"), 
                        React.createElement("option", {value: "2"}, "Verzekeringen")
                      )
                    ), 
                    React.createElement("div", {className: "form-group"}, 
                      React.createElement("label", {htmlFor: "text", className: "sr-only"}, "Year"), 
                      React.createElement("input", {type: "text", className: "form-control", id: "year", placeholder: "Enter year"})
                    ), 
                    React.createElement("div", {className: "form-group"}, 
                      React.createElement("label", {htmlFor: "month", className: "sr-only"}, "Month"), 
                      React.createElement("input", {type: "text", className: "form-control", id: "month", placeholder: "Enter month"})
                    ), 
                    React.createElement("div", {className: "form-group"}, 
                      React.createElement("label", {htmlFor: "description", className: "sr-only"}, "Description"), 
                      React.createElement("input", {type: "text", className: "form-control", id: "description", placeholder: "Enter description"})
                    ), 
                    React.createElement("div", {className: "form-group"}, 
                      React.createElement("label", {htmlFor: "amount", className: "sr-only"}, "Amount"), 
                      React.createElement("input", {type: "text", className: "form-control", id: "amount", placeholder: "Enter amount"})
                    ), 
                    React.createElement("div", {className: "btn btn-default"}, "Save")
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
          ), 
          React.createElement("div", {className: "row"}, 
            React.createElement("div", {className: "col-xs-12"}, 
              React.createElement("div", {className: "panel panel-default enter-mutation-form"}, 
                React.createElement("div", {className: "panel-body"}
                )
              )
            )
          )
        )
      );
    }
  });

  var component = React.render(React.createElement(myMoney.components.Mutations, null), document.getElementById('mutations-placeholder'));

  myMoney.page = myMoney.page || {};
  myMoney.page.mutations = component;
})(React);
