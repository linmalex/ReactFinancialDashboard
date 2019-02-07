import React, { Component } from "react";
import { FilterButton } from "./FilterButton";

export class YnabAccountBalances extends Component {
  getYnabAccountsData = () => {
    fetch("api/YNABCreditCard/YNABAccountsJson2")
      .then(response => response.json())
      .then(data => {
        var accounts = data;
        this.setState({ accounts, loading: false });
      });
  };

  handleFilter = () => {
    const accounts = this.state.accounts.filter(a => a.type === "creditCard");
    const filterButtonClass = "btn btn-danger";
    this.setState({ accounts, filterButtonClass });
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

  constructor(props) {
    super(props);
    this.state = {
      accounts: [],
      loading: true,
      filterButtonDetails: { className: "btn btn-primary" }
    };

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
          <FilterButton
            onFilter={this.handleFilter}
            filterButtonClass={this.state.filterButtonDetails.className}
          />
        </div>
        {contents}
      </div>
    );
  }
}
