import React, { Component } from "react";
import { Table } from "../LayoutComponents/Table";

export class PaymentsDue extends Component {
  constructor() {
    super();
    this.state = {
      pageTitle: "Credit Card Statements",
      data: [],
      dataLoading: true,
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
    fetch("api/YNABCreditCard/ServerStatements")
      .then(response => response.json())
      .then(data => {
        this.setState({ data, dataLoading: false });
      });
  }

  render() {
    let contents = this.state.dataLoading ? (
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
