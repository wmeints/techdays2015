(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  function getParameterByName(name) {
      name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
      var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
          results = regex.exec(location.search);
      return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
  }

  myMoney.components.Search = React.createClass({displayName: "Search",
    getInitialState: function() {
      var query = getParameterByName("query");

      return {
        results: [],
        query: query
      }
    },
    componentDidMount: function() {
      $.ajax({
        url: myMoney.settings.searchApiUrl + '/api/search?q=' + this.state.query,
        success: function(data) {
          this.setState({
            results: data
          });
        }.bind(this)
      })
    },
    render: function() {
      var results = [];
      var searchResultDisplay = "";

      if(this.state.results.length > 0) {
        for(var i = 0; i < this.state.results.length; i++) {
          var searchResult = this.state.results[i];

          results.push(
            React.createElement("tr", null, 
              React.createElement("td", null, searchResult.year), 
              React.createElement("td", null, searchResult.month), 
              React.createElement("td", null, searchResult.category), 
              React.createElement("td", null, searchResult.description), 
              React.createElement("td", null, searchResult.amount)
            )
          );
        }

        searchResultDisplay = React.createElement("div", {className: "row"}, 
          React.createElement("div", {className: "col-xs-12"}, 
            React.createElement("table", {className: "table"}, 
              React.createElement("thead", null, 
                React.createElement("tr", null, 
                  React.createElement("th", null, "Year"), 
                  React.createElement("th", null, "Month"), 
                  React.createElement("th", null, "Category"), 
                  React.createElement("th", null, "Amount")
                )
              ), 
              React.createElement("tbody", null, 
                results
              )
            )
          )
        );
      }

      return(
        React.createElement("div", {className: "search"}, 
          React.createElement("div", {className: "row"}, 
            React.createElement("div", {className: "col-xs-12"}, 
              React.createElement("h1", null, "Search results"), 
              React.createElement("p", {className: "text-muted"}, "Found ", this.state.results.length, " items that match your query '", this.state.query, "'")
            )
          ), 
          searchResultDisplay
        )
      );
    }
  });

  var component = React.render(React.createElement(myMoney.components.Search, null), document.getElementById('search-placeholder'));

  myMoney.page = myMoney.page || {};
  myMoney.page.search = component;
})(React);
