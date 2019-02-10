import React, { Component } from "react";
import { FilterButton } from "../UtilityComponents/FilterButton";
import { Table } from "../LayoutComponents/Table";

export class YnabAccountBalances extends Component {
  constructor() {
    super();
    this.state = {
      accounts: [],
      dataItemsToDisplay: [],
      columnDisplayTitles: ["Account Name", "Account Balance", "Account Type"],
      jsonTitleValues: ["Name", "Balance", "Type"]
    };
  }

  componentWillMount() {
    this.setState({
      accounts: this.props.state.accounts,
      dataItemsToDisplay: this.props.state.accounts
    });
  }

  filterAccounts = accountfilter => {
    let dataItemsToDisplay = this.state.accounts;
    if (accountfilter === "Credit Card") {
      dataItemsToDisplay = dataItemsToDisplay.filter(
        acct => acct.Type === accountfilter
      );
    }
    this.setState({ dataItemsToDisplay });
  };

  render() {
    let contents = this.props.state.loading ? (
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
