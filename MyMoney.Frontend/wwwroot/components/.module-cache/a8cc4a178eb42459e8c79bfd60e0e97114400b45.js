var ProgressBar = React.createClass({displayName: "ProgressBar",
  render: function() {  
    return (
      React.createElement("div", {className: "progress"}, 
        React.createElement("div", {className: "progress-bar progress-bar-success", style: {width: this.props.value + '%'}})
      )
    );
  }
});
