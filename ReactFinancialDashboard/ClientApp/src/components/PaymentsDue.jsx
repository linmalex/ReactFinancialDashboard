import React, { Component } from "react";

class PaymentsDue extends Component {
  static renderStatementsTable(statements) {
    return (
      <table className="table">
        <thead>
          <tr>
            <th>Statement Date</th>
            <th>Payment Due Date</th>
            <th>Statement Balance</th>
            <th>Minimum Payment</th>
          </tr>
        </thead>
        <tbody>
          {statements.map(statement => (
            <tr key={statement.id}>
              <td>{statement.name}</td>
              <td>{statement.balance}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  constructor(props) {
    super(props);
    this.state = { accounts: [], loading: true };

    this.getServerStatements();
  }

  getServerStatements = () => {
      fetch('api/YNABCreditCard/ServerStatements')
          .then(response => response.json())
          .then(data => {
              console.log(data);
              this.setState({ loading: false });
          });
  };


  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
            PaymentsDue.renderStatementsTable(this.state.accounts)
    );

    return (
      <div>
        <h1>Credit Cards</h1>
        {contents}
      </div>
    );
  }
}

export default PaymentsDue;
