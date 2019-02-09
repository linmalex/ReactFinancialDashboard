import React, { Component } from "react";

export class FilterButton extends Component {
  state = {
    classNames: "btn btn-primary"
  };

  render() {
    return (
      <button
        type="button"
        onClick={() => this.props.handleFilter("Credit Card")}
        className={this.props.filterButtonClass}
      >
        Filter
      </button>
    );
  }
}
