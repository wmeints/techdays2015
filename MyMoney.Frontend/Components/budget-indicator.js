(function(React) {
  myMoney = window.myMoney = window.myMoney || {};
  myMoney.components = myMoney.components || {};

  myMoney.components.BudgetIndicator = React.createClass({
    render: function() {
      var progressBarClasses = [];

      if(this.props.max >= this.props.value) {
        progressBarClasses.push('progress-bar-success');
      }

      if(this.props.max < this.props.value) {
        progressBarClasses.push('progress-bar-danger');
      }

      var progressValue = (100/this.props.max) * this.props.value;

      if(progressValue > 100) {
        progressValue = 100;
      }

      return (
        <div key={this.props.id} className="budget-indicator">
          <myMoney.components.ProgressBar value={progressValue} classes={progressBarClasses}/>
          <label>{this.props.name}: &euro;{this.props.value} ( max &euro;{this.props.max} )</label>
        </div>
      );
    }
  });
})(React);
