import React, { Component } from "react";
import { FinancialComponent } from "../LayoutComponents/FinancialComponent";

export class YnabAccountBalances extends Component {
  constructor() {
    super();
    this.state = {
      pageTitle: "Ynab Account Balances",
      data: [],
      dataLoading: true,
      columnDisplayTitles: ["Account Name", "Account Balance", "Account Type"],
      jsonTitleValues: ["Name", "Balance", "Type"]
    };
  }

  componentWillMount() {
    fetch("api/YNABCreditCard/DbYNABAccountsJson")
      .then(response => response.json())
      .then(data => {
        this.setState({ data, dataLoading: false });
      });
  }

  render() {
    return <FinancialComponent state={this.state} />;
  }
}
