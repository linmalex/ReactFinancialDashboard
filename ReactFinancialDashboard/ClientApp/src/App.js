import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { YnabAccountBalances } from "./components/YnabAccountBalances";
import { PaymentsDue } from "./components/PaymentsDue";

export default class App extends Component {
  displayName = App.name;

  render() {
    return (
      <Layout>
            <Route exact path="/" component={YnabAccountBalances} />
            <Route exact path="/PaymentsDue" component={PaymentsDue} />
        </Layout>

    );
  }
}
