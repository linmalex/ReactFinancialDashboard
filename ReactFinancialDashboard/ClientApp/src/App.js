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
      serverData: {
        personalDataID: 2
      }
    };
    this.callController("SetInitialState");
    this.getLocalYnabData("SetYnabAccountsJson");
    this.getServerStatements("SetServerStatements");
  }

  //#region //* Controller Calls -----------------------------------------------------------------------
  //* Calls to server to get initial state values RenderState

  callController = async controllerAction => {
    var initialStateURL = this.createURL(controllerAction);
    const response = await fetch(initialStateURL);
    const data = await response.json();
    return this.setState({ serverData: data, loading: false });
  };

  createURL = controllerAction => {
    const id = this.state.serverData.personalDataID;
    const params = `?ID=${id}`;
    const url = `api/Data/${controllerAction}${params}`;
    return url;
  };

  //* Calls to server to set data for 0th item in serverData.componentList
  //! should be refactored to be less dependent on hard coded array position
  getServerStatements = controllerAction => {
    const setServerStatementsURL = this.createURL(controllerAction);
    fetch(setServerStatementsURL)
      .then(response => response.json())
      .then(data => {
        let { serverData } = this.state;
        serverData.componentsList[0].data = data;
        this.setState({ serverData });
      });
  };
  //* Calls to server to set data for 1st item in serverData.componentList
  //! should be refactored to be less dependent on hard coded array position
  getLocalYnabData = controllerAction => {
    const setYnabAccountsURL = this.createURL(controllerAction);
    fetch(setYnabAccountsURL)
      .then(response => response.json())
      .then(data => {
        let { serverData } = this.state;
        serverData.componentsList[1].data = data;
        this.setState({ serverData });
      });
  };

  //* button called when button is clicked. Makes call to YNAB API, updates local server with new data.
  //! does not currently do anything with the data. This needs to be fixed
  getNewYnabData = () => {
    const updateYnabAccountsURL = this.createURL("UpdateLocalYnabData");
    fetch(updateYnabAccountsURL)
      .then(response => response.json())
      .then(data => {
        let { serverData } = this.state;
        serverData.componentsList[1].data = data;
        this.setState({ serverData });
      });
  };
  //#endregion

  //#region //* RENDER -----------------------------------------------------------------------
  //* uses state serverData to generate render Route and LoadingComponents
  generateLoadingComponents() {
    const componentData = this.state.serverData.componentsList;
    let renderedComponents = []; //empty array to hold rendered LoadingComponents

    for (let i in componentData) {
      const currentDataItem = componentData[i];
      let {
        dataLoading,
        pageTitle,
        columnDisplayTitles,
        data,
        jsonTitleValues
      } = currentDataItem;
      let loadingData = { dataLoading, pageTitle };
      let tableData = { columnDisplayTitles, data, jsonTitleValues };
      let routeItem = (
        <Route
          key={Math.random() * 10}
          exact
          path={currentDataItem.routePath}
          render={props => (
            <LoadingComponent
              loadingData={loadingData}
              tableData={tableData}
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
    var layout;
    this.state.loading
      ? (layout = <p>Loading</p>)
      : (layout = (
          <Layout appstate={this.state} getYnabData={this.getNewYnabData}>
            {this.generateLoadingComponents()}
          </Layout>
        ));

    return layout;
  }
  //#endregion
}
