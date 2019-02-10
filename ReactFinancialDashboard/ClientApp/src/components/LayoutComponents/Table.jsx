import React, { Component } from "react";

class Table extends Component {
  state = {};

  renderCreditCards = () => {
    const creditCards = this.props.creditCards;
    const thTitles = [
      "Account Name",
      "Statement Date",
      "Payment Due Date",
      "Statement Balance",
      "Minimum Payment",
      "YNAB Account Balance"
    ];

    return (
      <table className="table">
        <thead>
          <tr>
            {thTitles.map(title => (
              <th>{title}</th>
            ))}
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
  };

  render() {
    var statements = this.props.statements;
    const thTitles = [
      "Statement Date",
      "Payment Due Date",
      "Statement Balance",
      "Minimum Payment",
      "Paid Status"
    ];

    return (
      <table className="table">
        <thead>
          <tr>
            {statements.titles.map(title => (
              <th>{title}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {statements.data.map(statement => (
            <tr key={statement.ID}>
              <td>{statement.IssueDate}</td>
              <td>{statement.DueDate}</td>
              <td>{statement.Balance}</td>
              <td>{statement.MinPayment}</td>
              <td>{statement.PaidStatus}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }
}

export default Table;
