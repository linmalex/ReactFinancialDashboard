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
    fetch("api/Data/SetInitialState")
      .then(response => response.json())
      .then(data => this.setState({ serverData: data, loading: false }))
      .then(this.getServerStatements(), this.getLocalYnabData());
  };

  //* Calls to server to set data for 0th item in serverData.componentList
  //! should be refactored to be less dependent on hard coded array position
  getServerStatements = () => {
    fetch("api/Data/SetServerStatements")
      .then(response => response.json())
      .then(data => {
        let { serverData } = this.state;
        serverData.componentsList[0].data = data;
        this.setState({ serverData });
      });
  };
  //* Calls to server to set data for 1st item in serverData.componentList
  //! should be refactored to be less dependent on hard coded array position
  getLocalYnabData = () => {
    const data = new FormData({ ID: 1 });
    console.log(data);
    fetch("api/Data/SetYnabAccountsJson")
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
    fetch("api/Data/UpdateLocalYnabData")
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
