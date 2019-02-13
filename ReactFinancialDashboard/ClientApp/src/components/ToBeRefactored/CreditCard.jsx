import React, { Component } from "react";
import { LoadingComponent } from "../LayoutComponents/LoadingComponent";

export class CreditCard extends Component {
  constructor() {
    super();
    this.state = {
      pageTitle: "Full Credit Card Data",
      data: [],
      //todo change this back to true later
      dataLoading: false,
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
    return <LoadingComponent state={this.state} />;
  }
}
