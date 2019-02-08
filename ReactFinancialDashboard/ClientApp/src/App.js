import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/LayoutComponents/Layout";
import { YnabAccountBalances } from "./components/FinancialComponents/YnabAccountBalances";
import { PaymentsDue } from "./components/FinancialComponents/PaymentsDue";
import { ProjectPlan } from "./components/ProjectPlan";
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
      filterButtonDetails: { className: "btn btn-primary" },
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
    fetch("api/YNABCreditCard/ServerStatements")
      .then(response => response.json())
      .then(data => {
        var zero = data[0];
        console.log(zero);
        this.setState({ statements: data, statementsLoading: false });
      });
  };

  render() {
    return (
      <Layout>
        <Route exact path="/" component={ProjectPlan} />
        <Route
          exact
          path="/PaymentsDue"
          render={props => <PaymentsDue {...props} stateValues={this.state} />}
        />
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
          path="/CreateStatementForm"
          render={props => (
            <CreateStatementForm {...props} stateValues={this.state} />
          )}
        />
      </Layout>
    );
  }
}
