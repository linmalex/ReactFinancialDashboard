import React, { Component } from "react";

export class CreateForm extends Component {
  constructor() {
    super();
    this.handleSubmit = this.handleSubmit.bind(this);
    this.state = {
      submitResponse: "",
      toStatements: false,
      formfields: [
        {
          label: "Accounts",
          id: "accountSelect",
          name: "YnabAccountID",
          type: "select"
        },
        {
          label: "StatementDate",
          id: "IssueDate",
          name: "IssueDate",
          type: "input",
          inputType: "date"
        },
        {
          label: "Statement Balance",
          id: "statementBalance",
          name: "Balance",
          type: "input",
          inputType: "text"
        },
        {
          label: "Minimum Payment",
          id: "minPayment",
          name: "MinPayment",
          type: "input",
          inputType: "text"
        },
        {
          label: "Payment Due Date",
          id: "paymentDue",
          name: "DueDate",
          type: "input",
          inputType: "date"
        }
      ],
      data: [
        {
          Balance: 4473.82,
          Cleared_balance: 4473.82,
          Closed: false,
          CreditCardStatements: null,
          Deleted: false,
          ID: "ea31249c-947b-4adf-873d-abd533dd4b13",
          Name: "Joint Checking",
          Note: null,
          On_budget: true,
          PersonalData: null,
          Transfer_payee_id: "85c18465-a48e-4e6c-bb7f-57242014f393",
          Type: "Checking",
          Uncleared_balance: 0
        },
        {
          Balance: -11097.29,
          Cleared_balance: -10816.48,
          Closed: false,
          CreditCardStatements: null,
          Deleted: false,
          ID: "f81bad26-4fb3-419a-b49c-d71ee4afdcf8",
          Name: "Chase Amazon Card",
          Note: null,
          On_budget: true,
          PersonalData: null,
          Transfer_payee_id: "7b22e04f-8e25-4160-95a6-6eb7fdc82efc",
          Type: "Credit Card",
          Uncleared_balance: -280.81
        }
      ]
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
      .then(this.props.reRender);
  };

  renderTag = inputField => {
    var { ynabAccounts } = this.props.state;
    var Type = inputField.type;
    if (Type === "select") {
      return (
        <Type
          className="form-control"
          id={inputField.id}
          name={inputField.name}
        >
          <option>Select Account</option>
          {ynabAccounts.map(account => (
            <option key={account.ID} value={account.ID}>
              {account.Name}
            </option>
          ))}
        </Type>
      );
    } else {
      return (
        <Type
          type={inputField.inputType}
          className="form-control"
          id={inputField.id}
          name={inputField.name}
        />
      );
    }
  };

  renderFormDivs() {
    var divList = [];
    for (var i = 0; i < this.state.formfields.length; i++) {
      var currentField = this.state.formfields[i];
      var divreturn = (
        <div className="form-group">
          <label>{currentField.label}</label>
          {this.renderTag(currentField)}
        </div>
      );
      divList.push(divreturn);
    }
    return divList;
  }
  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        {this.renderFormDivs()}
        <button className="btn btn-primary" type="submit">
          Submit
        </button>
      </form>
    );
  }
}
