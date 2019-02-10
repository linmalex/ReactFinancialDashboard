import React, { Component } from "react";
import { Table } from "../LayoutComponents/Table";

export class CreditCard extends Component {
  constructor() {
    super();
    this.state = {
      pageTitle: "Full Credit Card Data",
      dataItemsToDisplay: [],
      columnDisplayTitles: [
        "Account Name",
        "Statement Date",
        "Payment Due Date",
        "Statement Balance",
        "Minimum Payment",
        "YNAB Account Balance"
      ],
      jsonTitleValues: [
        "name",
        "IssueDate",
        "DueDate",
        "Balance",
        "MinPayment",
        "balance"
      ]
    };
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
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
