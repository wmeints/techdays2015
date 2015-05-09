var ProgressBar = React.createClass({displayName: "ProgressBar",
  render: function() {
    var progressClasses = [];

    this.props.classes.forEach(function(item) {
      progressClasses.push(item);
    })

    return (
      React.createElement("div", {className: "progress"}, 
        React.createElement("div", {className: "progress-bar progress-bar-success", style: {width: this.props.value + '%'}})
      )
    );
  }
});
