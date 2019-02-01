import React, { Component } from "react";
// eslint-disable-next-line
import Bill from "./Bill";

class ListOfBills extends Component {
  state = {
    bills: [
      {
        id: 1,
        PayTo: "StateFarm",
        Category: "None",
        Amount: 252.41,
        Due: "2/1/2018",
        PaidStatus: "false",
        Type: "MonthlyBill",
        Memo: ""
      },
      {
        id: 2,
        Category: "None",
        PayTo: "Caliber Mortgages",
        Amount: 2045.89,
        Due: "2/1/2018",
        PaidStatus: "false",
        Type: "DebtPayment",
        Memo: ""
      },
      {
        id: 3,
        Category: "None",
        PayTo: "Chase Bank",
        Amount: 2000,
        Due: "2/1/2018",
        PaidStatus: "false",
        Type: "DebtPayment",
        Memo: ""
      }
    ]
  };

  render() {
    return <Bill bills={this.state.bills} />;
  }
}
export default ListOfBills;
