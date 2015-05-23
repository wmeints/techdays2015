(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  myMoney.components.Mutations = React.createClass({
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

      categories.push(<option value=''>-</option>);

      for(var i = 0; i < this.state.categories.length; i++) {
        categories.push(<option value={this.state.categories[i].id}>{this.state.categories[i].name}</option>);
      }

      for(var j = 0; j < this.state.mutations.length; j++) {
        mutations.push(
          <tr>
            <td>{this.state.mutations[j].category.name}</td>
            <td>{this.state.mutations[j].description}</td>
            <td>{this.state.mutations[j].amount}</td>
          </tr>
        );
      }

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
                  <form className="form-inline enter-mutation-form" onSubmit={this.saveMutation}>
                    <div className="form-group">
                      <label htmlFor="budget" className="sr-only">Budget</label>
                      <select className="form-control" id="budget" onChange={this.categorySelected}>
                        {categories}
                      </select>
                    </div>
                    <div className="form-group">
                      <label htmlFor="text" className="sr-only">Year</label>
                      <input type="text" className="form-control" id="year" autocomplete="false" placeholder="Enter year" value={this.state.newMutation.year} onChange={this.mutationYearChanged}/>
                    </div>
                    <div className="form-group">
                      <label htmlFor="month" className="sr-only">Month</label>
                      <input type="text" className="form-control" id="month" autocomplete="false" placeholder="Enter month" value={this.state.newMutation.month} onChange={this.mutationMonthChanged}/>
                    </div>
                    <div className="form-group">
                      <label htmlFor="description" className="sr-only">Description</label>
                      <input type="text" className="form-control" id="description" autocomplete="false" placeholder="Enter description" value={this.state.newMutation.description} onChange={this.mutationDescriptionChanged}/>
                    </div>
                    <div className="form-group">
                      <label htmlFor="amount" className="sr-only">Amount</label>
                      <input type="text" className="form-control" id="amount" placeholder="Enter amount" autocomplete="false" value={this.state.newMutation.amount} onChange={this.mutationAmountChanged}/>
                    </div>
                    <button type="submit" className="btn btn-default">Save</button>
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
                  <table className="table">
                    <thead>
                      <th>Category</th>
                      <th>Description</th>
                      <th>Amount</th>
                    </thead>
                    <tbody>
                      {mutations}
                    </tbody>
                  </table>
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
