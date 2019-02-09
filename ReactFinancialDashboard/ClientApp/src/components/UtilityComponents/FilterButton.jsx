import React, { Component } from "react";

export class FilterButton extends Component {
  state = {
    className: "btn btn-primary",
    filter: "Filter"
  };

  setBtnClasses = filter => {
    var className;
    if (filter === "Filter") {
      className = "btn btn-primary";
    } else {
      className = "btn btn-danger";
    }
    return className;
  };

  handleChange = () => {
    var filter = this.state.filter;
    if (filter == "Credit Card") {
      filter = "Filter";
    } else {
      filter = "Credit Card";
    }
    this.props.filterAccounts(filter);
    var className = this.setBtnClasses(filter);
    this.setState({ filter, className });
  };

  render() {
    return (
      <button
        type="button"
        onClick={this.handleChange}
        className={this.state.className}
      >
        {this.state.filter}
      </button>
    );
  }
}
