import React, { Component } from "react";

export class MyButton extends Component {
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
    let { buttonType } = this.props;
    let controllerInstructions = { action: "UpdateLocalYnabData", n: 1 };
    let button =
      buttonType === "getYnabData" ? (
        <button
          className={this.state.className}
          onClick={() => this.props.getYnabData(controllerInstructions)}
        >
          Get Ynab Data
        </button>
      ) : (
        <button
          type="button"
          onClick={this.handleChange}
          className={this.state.className}
        >
          Filter
        </button>
      );

    return button;
  }
}
