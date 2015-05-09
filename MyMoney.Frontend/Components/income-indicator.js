var IncomeIndicator = React.createClass({
  render: function() {
    return (
      <div key={this.props.id} className="income-indicator">
        <ProgressBar value={(100/this.props.max) * this.props.value} classes=""/>
        <label>{this.props.name} - &euro;{this.props.value}</label>
      </div>
    );
  }
});
