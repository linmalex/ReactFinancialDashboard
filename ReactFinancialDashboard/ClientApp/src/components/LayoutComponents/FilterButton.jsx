import React, { Component } from "react";

export class FilterButton extends Component {
  state = {
    className: "btn btn-primary",
    filter: false
  };

  handleChange = () => {
    this.props.handleFilter();

    var filter = this.state.filter;
    var className;

    if (filter) {
      className = "btn btn-primary";
      filter = false;
    } else {
      className = "btn btn-danger";
      filter = true;
    }
    this.setState({ filter, className });
  };

  render() {
    return (
      <button
        type="button"
        onClick={this.handleChange}
        className={this.state.className}
      >
        Filter
      </button>
    );
  }
}
