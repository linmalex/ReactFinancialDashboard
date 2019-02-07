import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { YnabAccountBalances } from "./components/YnabAccountBalances";
import { PaymentsDue } from "./components/PaymentsDue";
import { ProjectPlan } from "./components/ProjectPlan";
import { CreditCard } from "./components/CreditCard";
import { CreateForm } from "./components/CreateForm";

export default class App extends Component {
  displayName = App.name;

  constructor(props) {
    super(props);
    this.state = {
      accounts: [],
      loading: true,
      filterButtonDetails: { className: "btn btn-primary" },
      currentBudgetID: "ee4a0a66-fa5a-4838-9ab4-3f8f3f2103ed"
    };

    this.getYnabAccountsData();
  }

  getYnabAccountsData = () => {
    fetch("api/YNABCreditCard/DbYNABAccountsJson", {
      method: "post",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        currentBudgetID: this.state.currentBudgetID
      })
    })
      .then(response => response.json())
      .then(data => {
        var accounts = data;
        this.setState({ accounts, loading: false });
      });
  };
  render() {
    return (
      <Layout>
        <Route exact path="/" component={ProjectPlan} />
        <Route exact path="/PaymentsDue" component={PaymentsDue} />
        <Route
          exact
          path="/ynabaccountbalances"
          render={props => (
            <YnabAccountBalances {...props} stateValues={this.state} />
          )}
        />
        <Route exact path="/creditcard" component={CreditCard} />
        <Route
          exact
          path="/createform"
          render={props => <CreateForm {...props} stateValues={this.state} />}
        />
      </Layout>
    );
  }
}
