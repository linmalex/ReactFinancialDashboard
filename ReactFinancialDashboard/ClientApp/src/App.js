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
        personalDataID: 2,
        controllerActions: {
          setInitialState: "SetInitialState",
          getLocalYnabData: "SetYnabAccountsJson",
          getServerStatements: "SetServerStatements"
        }
      }
    };

    const {
      setInitialState,
      getLocalYnabData,
      getServerStatements
    } = this.state.serverData.controllerActions;

    this.callController(setInitialState);
    this.callSecondaryController(getLocalYnabData, 1);
    this.callSecondaryController(getServerStatements, 0);
  }

  //#region //* Controller Calls -----------------------------------------------------------------------
  //* Calls to server to get initial state values RenderState

  createURL = controllerAction => {
    const id = this.state.serverData.personalDataID;
    const params = `?ID=${id}`;
    const url = `api/Data/${controllerAction}${params}`;
    return url;
  };

  callController = async controllerAction => {
    const fetchURL = this.createURL(controllerAction);
    const response = await fetch(fetchURL);
    const data = await response.json();
    return this.setState({ serverData: data, loading: false });
  };

  callSecondaryController = async (controllerAction, n) => {
    const fetchURL = this.createURL(controllerAction);
    const response = await fetch(fetchURL);
    const data = await response.json();
    let { serverData } = this.state;
    serverData.componentsList[n].data = data;
    return this.setState({ serverData });
  };

  getNewYnabData = () => {
    const controllerAction = "UpdateLocalYnabData";
    const n = 1;
    this.callSecondaryController(controllerAction, n);
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
