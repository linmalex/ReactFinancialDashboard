import React, { Component } from "react";

export class CreateStatementForm extends Component {
  constructor() {
    super();
    this.handleSubmit = this.handleSubmit.bind(this);
    this.state = {
      submitResponse: ""
    };
  }

  handleSubmit = event => {
    event.preventDefault();
    const data = new FormData(event.target);
    fetch("api/YNABCreditCard/CreateStatement", {
      method: "post",
      body: data
    })
      .then(response => response.json())
      .then(data => (this.state.submitResponse = data));
  };

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        {/* Account select dropdown */}
        <div className="form-group">
          <label>Account</label>
          <select
            className="form-control"
            id="accountSelect"
            name="YnabAccountID"
          >
            <option>Select Account</option>
            {this.props.stateValues.accounts.map(account => (
              <option key={account.ID} value={account.ID}>
                {account.Name}
              </option>
            ))}
          </select>
        </div>
        {/* Statement date input */}
        <div className="form-group">
          <label htmlFor="statementDate">Statement Date</label>
          <input
            type="date"
            className="form-control"
            id="IssueDate"
            name="IssueDate"
          />
        </div>
        {/* Statement balance input */}
        <div className="form-group">
          <label htmlFor="statementBalance">Statement Balance</label>
          <input
            type="text"
            className="form-control"
            id="statementBalance"
            name="Balance"
          />
        </div>
        {/* Min payment input */}
        <div className="form-group">
          <label htmlFor="minPayment">Minimum Payment</label>
          <input
            type="text"
            className="form-control"
            id="minPayment"
            name="MinPayment"
          />
        </div>
        {/* Due date input */}
        <div className="form-group">
          <label htmlFor="paymentDue">Payment Due Date</label>
          <input
            type="date"
            className="form-control"
            id="paymentDue"
            name="DueDate"
          />
        </div>
        {/* Submit Button */}
        <button className="btn btn-primary" type="submit">
          Submit form
        </button>
      </form>
    );
  }
}
