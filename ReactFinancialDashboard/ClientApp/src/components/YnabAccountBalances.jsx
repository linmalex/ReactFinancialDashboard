import React, { Component } from "react";
import { FilterButton } from "./FilterButton";

export class YnabAccountBalances extends Component {
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

  render() {
    let contents = this.props.stateValues.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      YnabAccountBalances.renderAccountsTable(this.props.stateValues.accounts)
    );

    return (
      <div>
        <div className="row">
          <h1 className="col-9">YNAB Account Balances</h1>
          <FilterButton
            onFilter={this.handleFilter}
            filterButtonClass={
              this.props.stateValues.filterButtonDetails.className
            }
          />
        </div>
        {contents}
      </div>
    );
  }
}
