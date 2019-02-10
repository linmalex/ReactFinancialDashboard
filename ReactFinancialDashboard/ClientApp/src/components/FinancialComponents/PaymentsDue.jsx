import React, { Component } from "react";
import { Table } from "../LayoutComponents/Table";

export class PaymentsDue extends Component {
  render() {
    let contents = this.props.state.statementsLoading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      <Table data={this.props.state.statements} />
    );

    return (
      <div>
        <h1>Credit Cards</h1>
        {contents}
      </div>
    );
  }
}
