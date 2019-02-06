import React, { Component } from "react";

export class FilterButton extends Component {
  state = {
    classNames: "btn btn-primary"
  };

  render() {
    return (
      <button type="button" className={this.state.classNames}>
        Filter
      </button>
    );
  }
}
