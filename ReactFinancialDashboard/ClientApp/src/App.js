import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/LayoutComponents/Layout";
import { LoadingComponent } from "./components/LayoutComponents/LoadingComponent";
//todo uncomment this
// import { LoadingComponent } from "./components/LayoutComponents/LoadingComponent";

export default class App extends Component {
  displayName = App.name;

  constructor(props) {
    super(props);
    this.state = {
      currentBudgetID: "ee4a0a66-fa5a-4838-9ab4-3f8f3f2103ed",
      componentsList: {
        navMenuHeader: {
          navDisplayValues: "Lindsay's Financial Dashboard",
          routePath: "/"
        },
        navMenuItems: {
          paymentsDue: {
            navDisplayValues: "Payments Due",
            routePath: "/paymentsdue",
            glyph: "inbox",
            loadingData: {
              pageTitle: "Credit Card Statements",
              dataLoading: true
            },
            tableData: {
              data: [],
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
          ynabAccounts: {
            navDisplayValues: "Ynab Accounts",
            routePath: "/ynabaccountbalances",
            glyph: "piggy-bank",
            loadingData: {
              pageTitle: "Ynab Account Balances",
              dataLoading: true
            },
            tableData: {
              data: [],
              columnDisplayTitles: [
                "Account Name",
                "Account Balance",
                "Account Type"
              ],
              jsonTitleValues: ["Name", "Balance", "Type"]
            }
          },
          creditCards: {
            navDisplayValues: "Credit Card",
            routePath: "/creditcard",
            glyph: "credit-card",
            loadingData: {
              pageTitle: "Full Credit Card Data",
              //todo change this back to true later
              dataLoading: false
            },
            tableData: {
              data: [],
              columnDisplayTitles: [
                "Account Name",
                "Statement Date",
                "Payment Due Date",
                "Statement Balance",
                "Minimum Payment",
                "YNAB Account Balance"
              ],
              jsonTitleValues: [
                "Name",
                "IssueDate",
                "DueDate",
                "Balance",
                "MinPayment",
                "balance"
              ]
            }
          }
        }
      }
    };
  }
  // todo renderStatements() {}

  componentWillMount() {
    fetch("api/YNABCreditCard/ServerStatements")
      .then(response => response.json())
      .then(data => {
        let { componentsList: navMenu } = this.state;
        let { paymentsDue } = navMenu.navMenuItems;
        console.log(data);
        paymentsDue.tableData.data = data;
        paymentsDue.loadingData.dataLoading = false;
        this.setState({ navMenu });
      });

    fetch("api/YNABCreditCard/DbYNABAccountsJson")
      .then(response => response.json())
      .then(data => {
        let { componentsList: navMenu } = this.state;
        let { ynabAccounts } = navMenu.navMenuItems;
        ynabAccounts.tableData.data = data;
        ynabAccounts.loadingData.dataLoading = false;
        this.setState({ navMenu });
      });

    fetch("api/YNABCreditCard/GetAppData")
      .then(response => response.json())
      .then(data => {
        console.log(data);
        console.log(this.state);
      });
  }

  renderRouteItems() {
    const components = this.state.componentsList.navMenuItems;
    let componentList = [];

    for (let item in components) {
      const currentItem = components[item];
      let routeItem = (
        <Route
          key={Math.random() * 10}
          exact
          path={currentItem.routePath}
          render={props => (
            <LoadingComponent
              loadingData={currentItem.loadingData}
              tableData={currentItem.tableData}
              {...props}
            />
          )}
        />
      );
      componentList.push(routeItem);
    }

    return componentList;
  }

  getNewYnabData = () => {
    fetch("api/YNABCreditCard/GetNewYnabData")
      .then(response => response.json())
      .then(data => {
        console.log(data);
      });
  };

  render() {
    let components = this.renderRouteItems();
    return (
      <Layout
        navMenu={this.state.componentsList}
        getYnabData={this.getNewYnabData}
      >
        {components}
      </Layout>
    );
  }
}
