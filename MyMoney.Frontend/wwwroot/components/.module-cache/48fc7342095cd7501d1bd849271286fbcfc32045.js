var ProgressBar = React.createClass({displayName: "ProgressBar",
  render: function() {
    var progressClasses = ['progress-bar'];

    this.props.classes.forEach(function(item) {
      progressClasses.push(item);
    })

    return (
      React.createElement("div", {className: "progress"}, 
        React.createElement("div", {className: progressClasses, style: {width: this.props.value + '%'}})
      )
    );
  }
});
