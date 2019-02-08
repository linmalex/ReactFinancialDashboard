import React, { Component } from "react";

export class CreateForm extends Component {
  constructor() {
    super();
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleSubmit = event => {
    event.preventDefault();
    const data = new FormData(event.target);
    fetch("api/YNABCreditCard/CreateStatement", {
      method: "post",
      body: data
    }).then(response => response.json);
  };

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <div className="form-group">
          <label>Account</label>
          <select
            className="form-control"
            id="accountSelect"
            name="accountName"
          >
            <option>Select Account</option>
            {this.props.stateValues.accounts.map(account => (
              <option key={account.ID} value={account.ID}>
                {account.Name}
              </option>
            ))}
          </select>
        </div>
        <div className="form-group">
          <label htmlFor="statementDate">Statement Date</label>
          <input
            type="date"
            className="form-control"
            id="statementDate"
            name="statementDate"
          />
        </div>
        <div className="form-group">
          <label htmlFor="statementBalance">Statement Balance</label>
          <input
            type="text"
            className="form-control"
            id="statementBalance"
            name="statementBalance"
          />
        </div>
        <div className="form-group">
          <label htmlFor="minPayment">Minimum Payment</label>
          <input
            type="text"
            className="form-control"
            id="minPayment"
            name="minPayment"
          />
        </div>
        <div className="form-group">
          <label htmlFor="paymentDue">Payment Due Date</label>
          <input
            type="date"
            className="form-control"
            id="paymentDue"
            name="paymentDue"
          />
        </div>
        <button className="btn btn-primary" type="submit">
          Submit form
        </button>
      </form>
    );
  }
}
