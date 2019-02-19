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
      loading: true,
      currentBudgetID: "ee4a0a66-fa5a-4838-9ab4-3f8f3f2103ed",
      navDisplayValues: "Lindsay's Financial Dashboard",
      routePath: "/",
      componentsList: {
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
        }
      }
    };
    this.getInitialState();
  }
  // todo renderStatements() {}
  //* uses componentWillMount to call .NET controller method to get local server statements and local Ynab accounts
  componentWillMount() {
    fetch("api/YNABCreditCard/ServerStatements")
      .then(response => response.json())
      .then(data => {
        let { paymentsDue } = this.state.componentsList;
        paymentsDue.tableData.data = data;
        paymentsDue.loadingData.dataLoading = false;
        this.setState({ paymentsDue });
      });

    fetch("api/YNABCreditCard/DbYNABAccountsJson")
      .then(response => response.json())
      .then(data => {
        let { componentsList: navMenu } = this.state;
        let { ynabAccounts } = navMenu;
        ynabAccounts.tableData.data = data;
        ynabAccounts.loadingData.dataLoading = false;
        this.setState({ navMenu });
      });
  }
  //* uses this.state.componentsList to render Route and LoadingComponents
  renderLayoutComponents() {
    const components = this.state.componentsList; //manually created components list
    let componentList = []; //empty array to hold rendered LoadingComponents
    for (let item in components) {
      const currentItem = components[item]; //current working item from state data
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
  //*called on button click to call .NET controller method
  getNewYnabData = () => {
    fetch("api/YNABCreditCard/GetNewYnabData")
      .then(response => response.json())
      .then(data => {});
  };
  //*get initial state from .NET controller
  getInitialState = () => {
    fetch("api/YNABCreditCard/RenderState")
      .then(response => response.json())
      .then(data =>
        this.setState({ serverComponentsList: data, loading: false })
      );
  };

  render() {
    var renderData = this.state.loading ? (
      <Layout
        componentsList={this.state.componentsList}
        navDisplayValues={this.state.navDisplayValues}
        routePath={this.state.routePath}
        getYnabData={this.getNewYnabData}
        newStateData={this.serverComponentsList}
      >
        {this.renderLayoutComponents()}
      </Layout>
    ) : (
      <Layout
        componentsList={this.state.serverComponentsList} //* change this one
        navDisplayValues={this.state.navDisplayValues}
        routePath={this.state.routePath}
        getYnabData={this.getNewYnabData}
      >
        {this.renderLayoutComponents()}
      </Layout>
    );

    console.log(this.state.serverComponentsList);

    return renderData;
  }
}
