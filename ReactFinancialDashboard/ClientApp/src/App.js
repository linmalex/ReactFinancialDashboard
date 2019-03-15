import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/LayoutComponents/Layout";
import { BodyComponent } from "./components/LayoutComponents/BodyComponent";

export default class App extends Component {
  displayName = App.name;

  constructor(props) {
    super(props);
    this.state = {
      loading: true,
      serverData: {
        //description: determines which budget gets shown
        personalDataID: 2,
        //description: this.controllerInstructions determines which components get rendered.
        //... "action" determines which DataController method gets called
        //... "n" determines which level of serverData gets populated (to be refactored)
        //params
        controllerInstructions: {
          initialstate: {
            controller: "DataVM",
            method: "get",
            n: null
          },
          setYnabAccounts: {
            controller: "Accounts",
            method: "get",
            n: 1
          },
          setServerStatements: {
            controller: "CreditCardStatements",
            method: "get",
            n: 0
          }
        }
      }
    };

    const {
      initialstate,
      setYnabAccounts,
      setServerStatements
    } = this.state.serverData.controllerInstructions;

    this.callController(initialstate).then(
      this.callController(setYnabAccounts).then(
        this.callController(setServerStatements)
      )
    );
  }

  //#region //* UTILITIES -----------------------------------------------------------------------

  // description: uses state serverData to generate render Route and BodyComponents
  generateBodyComponents() {
    const componentData = this.state.serverData.componentsList;
    let renderedComponents = []; //empty array to hold rendered BodyComponents

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
            <BodyComponent
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
  //#endregion

  //#region //* CONTROLLER Call -----------------------------------------------------------------------
  // description: call controller to update state using controllerInstructions object as parameter
  //! needs to be refactored so as not to need n parameter to know which component to update

  callController = async controllerInstructions => {
    const { controller, method, n } = controllerInstructions;
    const personalDataID = this.state.serverData.personalDataID;
    const params = `${personalDataID}`;
    const url = `api/${controller}/${params}`;

    const response = await fetch(url, { method });
    const data = await response.json();
    let { serverData } = this.state;
    // description: hard coded instructions for which segment of serverData needs to be updated
    n == null
      ? (serverData = data)
      : (serverData.componentsList[n].data = data);
    console.log(serverData);
    return this.setState({ serverData, loading: false });
  };
  //#endregion

  //#region //* RENDER -----------------------------------------------------------------------
  render() {
    var layout;

    this.state.loading
      ? (layout = <p>Loading</p>)
      : (layout = (
          <Layout appstate={this.state} getYnabData={this.callController}>
            {this.generateBodyComponents()}
          </Layout>
        ));

    return layout;
  }
  //#endregion
}
