import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/LayoutComponents/Layout";
import { YnabAccountBalances } from "./components/ToBeRefactored/YnabAccountBalances";
import { PaymentsDue } from "./components/ToBeRefactored/PaymentsDue";
import { CreditCard } from "./components/ToBeRefactored/CreditCard";

export default class App extends Component {
  displayName = App.name;

  constructor(props) {
    super(props);
    this.state = {
      currentBudgetID: "ee4a0a66-fa5a-4838-9ab4-3f8f3f2103ed",
      navMenu: {
        navMenuHeader: {
          displayValues: "Lindsay's Financial Dashboard",
          toValue: "/",
          glyph: "home"
        },
        navMenuItems: [
          {
            displayValues: "Payments Due",
            toValue: "/paymentsdue",
            component: PaymentsDue,
            glyph: "home"
          },
          {
            displayValues: "Ynab Accounts",
            toValue: "/ynabaccountbalances",
            component: YnabAccountBalances,
            glyph: "home"
          },
          {
            displayValues: "Credit Card",
            toValue: "/creditcard",
            component: CreditCard,
            glyph: "home"
          }
        ]
      },
      routeItems: [
        <Route
          exact
          path="/PaymentsDue"
          render={props => <PaymentsDue {...props} />}
        />,
        <Route
          exact
          path="/ynabaccountbalances"
          render={props => <YnabAccountBalances {...props} />}
        />,
        <Route exact path="/creditcard" component={CreditCard} />
      ]
    };
  }

  renderRouteItems = () => {
    let routeItems = this.linkcontainers.map(item => (
      <Route
        key={Math.random() * 10}
        path={item.toValue}
        render={props => <item.Component {...props} />}
      />
    ));
    return routeItems;
  };

  render() {
    return (
      <Layout navMenu={this.state.navMenu}>{this.state.routeItems}</Layout>
    );
  }
}
