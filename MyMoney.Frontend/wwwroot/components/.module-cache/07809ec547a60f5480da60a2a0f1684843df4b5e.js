var ProgressBar = React.createClass({displayName: "ProgressBar",
  render: function() {
    var progressBarClasses = ['progress-bar'];

    if(this.props.classes) {
      this.props.classes.forEach(function(item) {
        progressBarClasses.push(item);
      });
    }

    return (
      React.createElement("div", {className: "progress"}, 
        React.createElement("div", {className: progressBarClasses, style: {width: this.props.value + '%'}})
      )
    );
  }
});
