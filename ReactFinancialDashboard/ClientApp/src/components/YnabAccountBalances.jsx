import React, { Component } from "react";
import { FilterButton } from "./FilterButton";

export class YnabAccountBalances extends Component {
  getYnabAccountsData = () => {
    fetch("api/YNABCreditCard/YNABAccountsJson")
      .then(response => response.json())
      .then(data => {
        var accounts = data["data"]["accounts"];
        for (var i = 0; i < accounts.length; i++) {
          accounts[i]["balance"] /= 1000;
        }
        this.setState({ accounts, loading: false });
      });
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
            <tr key={account.id}>
              <td>{account.name}</td>
              <td>${account.balance}</td>
              <td>{account.type}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  constructor(props) {
    super(props);
    this.state = { accounts: [], loading: true };

    this.getYnabAccountsData();
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      YnabAccountBalances.renderAccountsTable(this.state.accounts)
    );

    return (
      <div>
        <div className="row">
          <h1 className="col-9">YNAB Account Balances</h1>
          <FilterButton onFilterClick={this.handleFilterclick} />
        </div>
        {contents}
      </div>
    );
  }
}
