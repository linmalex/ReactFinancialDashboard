import React, { Component } from "react";

export class FilterButton extends Component {
  state = {
    classNames: "btn btn-primary",
    filter: "Credit Card"
  };

  handleChange = () => {
    var filter = this.state.filter;
    this.props.filterAccounts(filter);
    if (filter == "Credit Card") {
      filter = "";
    } else {
      filter = "Credit Card";
    }
    this.setState({ filter });
  };

  render() {
    return (
      <button
        type="button"
        onClick={this.handleChange}
        className={this.props.filterButtonClass}
      >
        Filter
      </button>
    );
  }
}
