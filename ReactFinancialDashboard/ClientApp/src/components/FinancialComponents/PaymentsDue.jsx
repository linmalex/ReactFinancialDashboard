import React, { Component } from "react";
import { Table } from "../LayoutComponents/Table";

export class PaymentsDue extends Component {
  constructor() {
    super();
    this.state = {
      pageTitle: "Credit Cards",
      dataItemsToDisplay: [],
      columnDisplayTitles: [
        "Statement Date",
        "Payment Due Date",
        "Statement Balance",
        "Minimum Payment",
        "Paid Status"
      ],
      jsonTitleValues: [
        "IssueDate",
        "DueDate",
        "Balance",
        "MinPayment",
        "PaidStatus"
      ]
    };
  }

  componentWillMount() {
    this.setState({
      dataItemsToDisplay: this.props.state.statements
    });
  }
  render() {
    let contents = this.props.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      // <Table state={this.state} />
      // PaymentsDue.renderStatementsTable(this.props.stateValues.statements)
      <Table state={this.state} />
    );

    return (
      <div>
        <h1>{this.state.pageTitle}</h1>
        {contents}
      </div>
    );
  }
}
