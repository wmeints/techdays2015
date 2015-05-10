var BudgetStateSelector = React.createClass({displayName: "BudgetStateSelector",
	render: function() {
		return (
			React.createElement("div", {className: "pull-right page-control"}, 
				React.createElement("form", {className: "form-inline"}, 
					React.createElement("div", {className: "form-group"}, 
						React.createElement("label", {for: "month", className: "sr-only"}, "Month"), 
						React.createElement("select", {id: "month", name: "month", className: "form-control"}, 
							React.createElement("option", null, "january"), 
							React.createElement("option", null, "february"), 
							React.createElement("option", null, "march"), 
							React.createElement("option", null, "april"), 
							React.createElement("option", null, "may"), 
							React.createElement("option", null, "june"), 
							React.createElement("option", null, "july"), 
							React.createElement("option", null, "august"), 
							React.createElement("option", null, "september"), 
							React.createElement("option", null, "october"), 
							React.createElement("option", null, "november"), 
							React.createElement("option", null, "december")
						)
					), 
					React.createElement("div", {className: "form-group"}, 
						React.createElement("label", {for: "year", className: "sr-only"}, "Year"), 
						React.createElement("input", {type: "number", className: "form-control", id: "year", name: "year", placeholder: "Enter year"})
					)
				)	
			)
		);
	}
});