var BudgetTotalItem = React.createClass({
  render: function() {
    return(
      <div className="row">
          <div className="col-xs-12">
              <div className="category-title">{this.props.name}</div>
              <div className="category-value">&euro; {this.props.value}</div>
          </div>
      </div>
    );
  }
});
