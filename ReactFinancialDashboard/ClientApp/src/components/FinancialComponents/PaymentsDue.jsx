import React, { Component } from "react";

export class PaymentsDue extends Component {
  static renderStatementsTable(statements) {
    return (
      <table className="table">
        <thead>
          <tr>
            <th>Statement Date</th>
            <th>Payment Due Date</th>
            <th>Statement Balance</th>
            <th>Minimum Payment</th>
            <th>Paid Status</th>
          </tr>
        </thead>
        <tbody>
          {statements.map(statement => (
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

  render() {
    let contents = this.props.state.statementsLoading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      PaymentsDue.renderStatementsTable(this.props.state.statements)
    );

    return (
      <div>
        <h1>Credit Cards</h1>
        {contents}
      </div>
    );
  }
}
