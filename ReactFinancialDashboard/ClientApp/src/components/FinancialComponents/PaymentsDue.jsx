import React, { Component } from "react";
import { FinancialComponent } from "../LayoutComponents/FinancialComponent";

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
    return <FinancialComponent state={this.state} />;
  }
}
