var BudgetTotal = React.createClass({
  render: function() {
    var items = [];

    this.props.items.forEach(function(item) {
      items.push(<BudgetTotalItem value={item.value} name={item.name}/>);
    }.bind(this));

    return (
      <div className="panel panel-default totals">
          <div className="panel-body">
              {items}

              <div className="row">
                <div className="col-xs-12">
                  <hr/>
                </div>
              </div>
              <div className="row">
                <div className="col-xs-12">
                  <div className="pull-right">
                    &euro; {this.props.result}
                  </div>
                </div>
              </div>
          </div>
      </div>
    );
  }
});
