import React, { Component } from "react";

export class Home extends Component {
  displayName = Home.name;

  render() {
    fetch("api/YnabAccount/YnabAccounts").then(data => console.log(data));
    return <div>3:40 PM</div>;
  }
}
