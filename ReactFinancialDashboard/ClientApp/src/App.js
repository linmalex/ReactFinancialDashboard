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
      loading: true
    };

    this.getInitialState();
  }

  //#region //* Server Calls -----------------------------------------------------------------------
  //* Calls to server to get initial state values RenderState
  getInitialState = () => {
    fetch("api/YNABCreditCard/RenderState")
      .then(response => response.json())
      .then(data => this.setState({ serverData: data, loading: false }));
  };

  //* button called when button is clicked. Makes call to YNAB API, updates local server with new data.
  //! does not currently do anything with the data. This needs to be fixed
  getNewYnabData = () => {
    fetch("api/YNABCreditCard/GetNewYnabData")
      .then(response => response.json())
      .then(data => {});
  };
  //#endregion

  //#region //* RENDER -----------------------------------------------------------------------
  //* uses state serverData to generate render Route and LoadingComponents
  generateLoadingComponents() {
    const componentData = this.state.serverData.componentsList;
    let renderedComponents = []; //empty array to hold rendered LoadingComponents

    for (let i in componentData) {
      const currentDataItem = componentData[i];
      let routeItem = (
        <Route
          key={Math.random() * 10}
          exact
          path={currentDataItem.routePath}
          render={props => (
            <LoadingComponent
              loadingData={currentDataItem.loadingData}
              tableData={currentDataItem.tableData}
              {...props}
            />
          )}
        />
      );
      renderedComponents.push(routeItem);
    }
    return renderedComponents;
  }

  render() {
    return this.state.loading ? (
      <p>Loading</p>
    ) : (
      <Layout appstate={this.state} getYnabData={this.getNewYnabData}>
        {this.generateLoadingComponents()}
      </Layout>
    );
  }
  //#endregion

  //#region //! to be refactored -----------------------------------------------------------------------
  getServerStatements = () => {
    fetch("api/YNABCreditCard/ServerStatements")
      .then(response => response.json())
      .then(data => {
        // console.log(data);
      });
  };
  getLocalYnabData = () => {
    fetch("api/YNABCreditCard/DbYNABAccountsJson")
      .then(response => response.json())
      .then(data => {
        let ynabAccounts = this.state.serverData.componentsList[1].tableData
          .data;
        this.setState({ ynabAccounts: data });
      });
  };
  //#endregion
}
