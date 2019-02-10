import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/LayoutComponents/Layout";
import { YnabAccountBalances } from "./components/FinancialComponents/YnabAccountBalances";
import { PaymentsDue } from "./components/FinancialComponents/PaymentsDue";
import { CreditCard } from "./components/FinancialComponents/CreditCard";
import { CreateStatementForm } from "./components/CreateStatementForm";

export default class App extends Component {
  displayName = App.name;

  constructor(props) {
    super(props);
    this.state = {
      accounts: [],
      accountsLoading: true,
      statements: [],
      statementsLoading: true,
      currentBudgetID: "ee4a0a66-fa5a-4838-9ab4-3f8f3f2103ed"
    };

    this.getYnabAccountsData();
    this.getServerStatements();
  }

  getYnabAccountsData = () => {
    fetch("api/YNABCreditCard/DbYNABAccountsJson")
      .then(response => response.json())
      .then(data => {
        var accounts = data;
        this.setState({ accounts, accountsLoading: false });
      });
  };

  getServerStatements = () => {
    const thTitles = [
      "Statement Date",
      "Payment Due Date",
      "Statement Balance",
      "Minimum Payment",
      "Paid Status"
    ];
    fetch("api/YNABCreditCard/ServerStatements")
      .then(response => response.json())
      .then(data => {
        var statements = { titles: thTitles, data: data };
        this.setState({ statements: statements, statementsLoading: false });
      });
  };

  render() {
    return (
      <Layout>
        <Route
          exact
          path="/PaymentsDue"
          render={props => <PaymentsDue {...props} state={this.state} />}
        />
        <Route
          exact
          path="/ynabaccountbalances"
          render={props => (
            <YnabAccountBalances {...props} state={this.state} />
          )}
        />
        <Route exact path="/creditcard" component={CreditCard} />
        <Route
          exact
          path="/CreateStatementForm"
          render={props => (
            <CreateStatementForm
              {...props}
              state={this.state}
              reRenderStatements={this.getServerStatements}
            />
          )}
        />
      </Layout>
    );
  }
}
