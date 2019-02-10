import React, { Component } from "react";
import { FinancialComponent } from "../LayoutComponents/FinancialComponent";

export class CreditCard extends Component {
  constructor() {
    super();
    this.state = {
      pageTitle: "Full Credit Card Data",
      data: [],
      dataLoading: true,
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

  // componentWillMount() {
  //   fetch("api/YNABCreditCard/ServerStatements")
  //     .then(response => response.json())
  //     .then(data => {
  //       this.setState({ data, dataLoading: false });
  //     });
  // }

  render() {
    return <FinancialComponent state={this.state} />;
  }
}
