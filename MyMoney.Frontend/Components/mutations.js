(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  myMoney.components.Mutations = React.createClass({
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
        <div className="mutations">
          <div className="row">
            <div className="col-xs-12">
              <h1>Mutations</h1>
            </div>
          </div>
          <div className="row">
            <div className="col-xs-12">
              <div className="panel panel-default">
                <div className="panel-body">
                  <form className="form-inline enter-mutation-form">
                    <div className="form-group">
                      <label htmlFor="budget" className="sr-only">Budget</label>
                      <select className="form-control" id="budget">
                        <option>-</option>
                        <option value="1">Huis</option>
                        <option value="2">Energie</option>
                        <option value="2">Verzekeringen</option>
                      </select>
                    </div>
                    <div className="form-group">
                      <label htmlFor="text" className="sr-only">Year</label>
                      <input type="text" className="form-control" id="year" placeholder="Enter year"/>
                    </div>
                    <div className="form-group">
                      <label htmlFor="month" className="sr-only">Month</label>
                      <input type="text" className="form-control" id="month" placeholder="Enter month"/>
                    </div>
                    <div className="form-group">
                      <label htmlFor="description" className="sr-only">Description</label>
                      <input type="text" className="form-control" id="description" placeholder="Enter description"/>
                    </div>
                    <div className="form-group">
                      <label htmlFor="amount" className="sr-only">Amount</label>
                      <input type="text" className="form-control" id="amount" placeholder="Enter amount"/>
                    </div>
                    <div className="btn btn-default">Save</div>
                  </form>
                </div>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-xs-12">
              <form className="form-inline mutations-state-selector" onSubmit={this.loadMutations}>
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
          <div className="row">
            <div className="col-xs-12">
              <div className="panel panel-default enter-mutation-form">
                <div className="panel-body">
                </div>
              </div>
            </div>
          </div>
        </div>
      );
    }
  });

  var component = React.render(<myMoney.components.Mutations/>, document.getElementById('mutations-placeholder'));

  myMoney.page = myMoney.page || {};
  myMoney.page.mutations = component;
})(React);
