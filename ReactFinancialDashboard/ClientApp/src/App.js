import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/LayoutComponents/Layout";
import { YnabAccountBalances } from "./components/ToBeRefactored/YnabAccountBalances";
import { PaymentsDue } from "./components/ToBeRefactored/PaymentsDue";
import { CreditCard } from "./components/ToBeRefactored/CreditCard";
import { LoadingComponent } from "./components/LayoutComponents/LoadingComponent";

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
            glyph: "home",
            data: {
              pageTitle: "Credit Card Statements",
              data: [],
              dataLoading: true,
              ynabAccounts: [],
              columnDisplayTitles: [
                "Statement Date",
                "Payment Due Date",
                "Statement Balance",
                "Minimum Payment",
                "Paid Status"
              ],
              jsonTitleValues: [
                "IssueDate",
                "DueDate",
                "Balance",
                "MinPayment",
                "PaidStatus"
              ]
            }
          },
          {
            displayValues: "Ynab Accounts",
            toValue: "/ynabaccountbalances",
            component: YnabAccountBalances,
            glyph: "home",
            data: {
              pageTitle: "Ynab Account Balances",
              data: [],
              dataLoading: true,
              columnDisplayTitles: [
                "Account Name",
                "Account Balance",
                "Account Type"
              ],
              jsonTitleValues: ["Name", "Balance", "Type"]
            }
          },
          {
            displayValues: "Credit Card",
            toValue: "/creditcard",
            component: CreditCard,
            glyph: "home",
            data: {
              pageTitle: "Full Credit Card Data",
              data: [],
              //todo change this back to true later
              dataLoading: false,
              columnDisplayTitles: [
                "Account Name",
                "Statement Date",
                "Payment Due Date",
                "Statement Balance",
                "Minimum Payment",
                "YNAB Account Balance"
              ],
              jsonTitleValues: [
                "name",
                "IssueDate",
                "DueDate",
                "Balance",
                "MinPayment",
                "balance"
              ]
            }
          }
        ]
      }
    };
  }

  renderRouteItems() {
    const components = this.state.navMenu.navMenuItems;
    let componentList = [];
    for (let item in components) {
      let Component = components[item].component;
      let routeItem = (
        <Route
          key={item}
          exact
          path={components[item].toValue}
          render={props => <Component {...props} />}
        />
      );
      componentList.push(routeItem);
    }
    return componentList;
  }

  render() {
    let components = this.renderRouteItems();
    return <Layout navMenu={this.state.navMenu}>{components}</Layout>;
  }
}
