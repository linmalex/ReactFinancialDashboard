import React, { Component } from "react";
import { Table } from "../LayoutComponents/Table";

export class YnabAccountBalances extends Component {
  constructor() {
    super();
    this.state = {
      pageTitle: "Ynab Account Balances",
      accounts: [],
      accountsLoading: true,
      dataItemsToDisplay: [],
      columnDisplayTitles: ["Account Name", "Account Balance", "Account Type"],
      jsonTitleValues: ["Name", "Balance", "Type"]
    };
  }

  componentWillMount() {
    fetch("api/YNABCreditCard/DbYNABAccountsJson")
      .then(response => response.json())
      .then(data => {
        this.setState({ dataItemsToDisplay: data, accounts: data });
      });
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
        <div className="row">
          <h1>{this.state.pageTitle}</h1>
        </div>
        {contents}
      </div>
    );
  }
}
