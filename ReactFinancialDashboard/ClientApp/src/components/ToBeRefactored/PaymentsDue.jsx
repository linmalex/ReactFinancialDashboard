import React, { Component } from "react";
import { LoadingComponent } from "../LayoutComponents/LoadingComponent";
import { CreateForm } from "../LayoutComponents/CreateForm";

export class PaymentsDue extends Component {
  constructor() {
    super();
    this.state = {
      pageTitle: "Credit Card Statements",
      data: [],
      dataLoading: true,
      ynabAccounts: [],
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

  renderStatements() {
    fetch("api/YNABCreditCard/ServerStatements")
      .then(response => response.json())
      .then(data => {
        this.setState({ data, dataLoading: false });
      });
  }
  componentWillMount() {
    this.renderStatements();

    fetch("api/YNABCreditCard/DbYNABAccountsJson")
      .then(response => response.json())
      .then(data => {
        this.setState({ ynabAccounts: data, dataLoading: false });
      });
  }

  render() {
    return (
      <div>
        <LoadingComponent state={this.state} />
        <CreateForm state={this.state} reRender={this.renderStatements} />
      </div>
    );
  }
}
