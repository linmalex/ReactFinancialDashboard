import React, { Component } from "react";
// Component to hold credit card plan => snowball method plan, last payment date, budgeted amounts, etc.

export class CreditCard extends Component {
  static renderfulltable(creditCards) {
    return (
      <table className="table">
        <thead>
          <tr>
            <th>Account Name</th>
            <th>Statement Date</th>
            <th>Payment Due Date</th>
            <th>Statement Balance</th>
            <th>Minimum Payment</th>
            <th>YNAB Account Balance</th>
          </tr>
        </thead>
        <tbody>
          {creditCards.map(creditCard => (
            <tr key={creditCard.ID}>
              <td>{creditCard.name}</td>
              <td>{creditCard.IssueDate}</td>
              <td>{creditCard.DueDate}</td>
              <td>{creditCard.Balance}</td>
              <td>{creditCard.MinPayment}</td>
              <td>{creditCard.balance}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  constructor(props) {
    super(props);
    this.state = { creditCards: [], loading: true };
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      CreditCard.renderfulltable(this.state.accounts)
    );

    return (
      <div>
        <h1>Credit Cards</h1>
        {contents}
      </div>
    );
  }
}
