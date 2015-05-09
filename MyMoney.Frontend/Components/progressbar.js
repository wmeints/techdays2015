var ProgressBar = React.createClass({
  render: function() {
    var progressBarClasses = ['progress-bar'];

    if(this.props.classes) {
      this.props.classes.forEach(function(item) {
        progressBarClasses.push(item);
      });
    }

    return (
      <div className='progress'>
        <div className={progressBarClasses.join(' ')} style={{width: this.props.value + '%'}}/>
      </div>
    );
  }
});
