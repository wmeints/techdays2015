(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  function getParameterByName(name) {
      name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
      var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
          results = regex.exec(location.search);
      return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
  }

  myMoney.components.Search = React.createClass({
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
      var searchResultDisplay = <p></p>;

      if(this.state.results.length > 0) {
        for(var i = 0; i < this.state.results.length; i++) {
          var searchResult = this.state.results[i];

          results.push(
            <tr>
              <td>{searchResult.year}</td>
              <td>{searchResult.month}</td>
              <td>{searchResult.category}</td>
              <td>{searchResult.description}</td>
              <td>{searchResult.amount}</td>
            </tr>
          );
        }

        searchResultDisplay = <div className="row">
          <div className="col-xs-12">
            <table className="table">
              <thead>
                <tr>
                  <th>Year</th>
                  <th>Month</th>
                  <th>Category</th>
                  <th>Amount</th>
                </tr>
              </thead>
              <tbody>
                {results}
              </tbody>
            </table>
          </div>
        </div>;
      }

      return(
        <div className="search">
          <div className="row">
            <div className="col-xs-12">
              <h1>Search results</h1>
              <p>Found {this.state.results.length} items that match your query '{this.state.query}'</p>
            </div>
          </div>
          {searchResultDisplay}
        </div>
      );
    }
  });

  var component = React.render(<myMoney.components.Search/>, document.getElementById('search-placeholder'));

  myMoney.page = myMoney.page || {};
  myMoney.page.search = component;
})(React);
