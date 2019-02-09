import React, { Component } from "react";
import { FilterButton } from "../UtilityComponents/FilterButton";

export class YnabAccountBalances extends Component {
  constructor() {
    super();
    this.state = {
      accounts: [],
      filteredAccounts: []
    };
  }

  componentWillMount() {
    this.setState({
      accounts: this.props.state.accounts,
      filteredAccounts: this.props.state.accounts
    });
  }

  filterAccounts = accountfilter => {
    let filteredAccounts = this.state.accounts;
    if (accountfilter === "Credit Card") {
      filteredAccounts = filteredAccounts.filter(
        acct => acct.Type === accountfilter
      );
    }
    this.setState({ filteredAccounts });
  };

  static renderAccountsTable(accounts) {
    return (
      <table className="table">
        <thead>
          <tr>
            <th>Account Name</th>
            <th>Account Balance</th>
            <th>Account Type</th>
          </tr>
        </thead>
        <tbody>
          {accounts.map(account => (
            <tr key={account.ID}>
              <td>{account.Name}</td>
              <td>${account.Balance}</td>
              <td>{account.Type}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.props.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      YnabAccountBalances.renderAccountsTable(this.state.filteredAccounts)
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
