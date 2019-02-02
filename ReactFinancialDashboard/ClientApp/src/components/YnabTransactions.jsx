import React, { Component } from "react";

class YnabTransactions extends Component {
  static renderTransactionsTable(transactions) {
    return (
      <table className="table">
        <thead>
          <tr>
            <th scope="col">Pay To</th>
            <th scope="col">Category</th>
            <th scope="col">Amount</th>
            <th scope="col">Due</th>
            <th scope="col">Memo</th>
          </tr>
        </thead>
        <tbody>
          {transactions.map(transaction => (
            <tr key={transaction.id}>
              <td>{transaction.payee_name}</td>
              <td>{transaction.category_name}</td>
              <td>{transaction.amount}</td>
              <td>{transaction.date}</td>
              <td>{transaction.Memo}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }
  constructor(props) {
    super(props);
    this.state = { transactions: [], loading: true };

    fetch("api/Transaction/GetYnabTransactions")
      .then(response => response.json())
      .then(data => {
        this.setState({ transactions: data, loading: false });
      });
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      this.renderTransactionsTable(this.state.transactions)
    );

    return (
      <div>
        <h1>Transactions</h1>
        {contents}
      </div>
    );
  }
}
export default YnabTransactions;
