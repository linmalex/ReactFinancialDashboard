import React, { Component } from "react";

export class Home extends Component {
  displayName = Home.name;

  state = {
    accounts: []
  };

  getAccounts = () => {
    fetch("api/YnabAccount/YNABAccountsJson")
      .then(response => response.json())
      .then(data => {
        var results = data["data"]["accounts"];
        console.log(typeof results);
        var accounts = [];
        for (var x in results) {
          accounts.push(typeof x);
        }
        console.log(accounts);
      });
  };

  render() {
    this.getAccounts();
    return <div>{this.state.accounts}</div>;
  }
}
