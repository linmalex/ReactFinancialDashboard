import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/LayoutComponents/Layout";
import { YnabAccountBalances } from "./components/ToBeRefactored/YnabAccountBalances";
import { PaymentsDue } from "./components/ToBeRefactored/PaymentsDue";
import { CreditCard } from "./components/ToBeRefactored/CreditCard";
import { CreateForm } from "./components/LayoutComponents/CreateForm";

export default class App extends Component {
  displayName = App.name;

  constructor(props) {
    super(props);
    this.state = {
      currentBudgetID: "ee4a0a66-fa5a-4838-9ab4-3f8f3f2103ed"
    };
  }

  render() {
    return (
      <Layout>
        <Route
          exact
          path="/PaymentsDue"
          render={props => <PaymentsDue {...props} />}
        />
        <Route
          exact
          path="/ynabaccountbalances"
          render={props => <YnabAccountBalances {...props} />}
        />
        <Route exact path="/creditcard" component={CreditCard} />
      </Layout>
    );
  }
}
