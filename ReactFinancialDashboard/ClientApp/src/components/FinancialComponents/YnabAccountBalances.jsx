import React, { Component } from "react";
import { FilterButton } from "../UtilityComponents/FilterButton";
import { Table } from "../LayoutComponents/Table";

export class YnabAccountBalances extends Component {
  constructor() {
    super();
    this.state = {
      accounts: [],
      accountsLoading: true,
      dataItemsToDisplay: [],
      columnDisplayTitles: ["Account Name", "Account Balance", "Account Type"],
      jsonTitleValues: ["Name", "Balance", "Type"],
      filtered: false
    };
    // this.getYnabAccountsData();
  }

  componentWillMount() {
    fetch("api/YNABCreditCard/DbYNABAccountsJson")
      .then(response => response.json())
      .then(data => {
        this.setState({ dataItemsToDisplay: data, accounts: data });
      });
    console.log("mount");
  }

  filterAccounts = accountfilter => {
    let { dataItemsToDisplay, accounts } = this.state;
    if (!this.state.filtered) {
      dataItemsToDisplay = dataItemsToDisplay.filter(
        acct => acct.Type === accountfilter
      );
      this.setState({ filtered: true, dataItemsToDisplay });
    } else {
      dataItemsToDisplay = accounts;
      this.setState({ filtered: false, dataItemsToDisplay });
    }
  };

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
          <h1 className="col-9">YNAB Account Balances</h1>
          <FilterButton filterAccounts={this.filterAccounts} />
        </div>
        {contents}
      </div>
    );
  }
}
