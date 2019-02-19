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

  getInitialState = () => {
    fetch("api/YNABCreditCard/RenderState")
      .then(response => response.json())
      .then(data => this.setState({ serverComponentsList: data, loading:false }));
  };

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
        // console.log(data);
      });
  };

  renderLayoutComponents() {
    const components = this.state.serverComponentsList.componentsList; //manually created components list
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

  getNewYnabData = () => {
    fetch("api/YNABCreditCard/GetNewYnabData")
      .then(response => response.json())
      .then(data => {});
  };

  render() {
    return this.state.loading ? (
      <p>"Loading</p>
    ) : (
      <Layout appstate={this.state} getYnabData={this.getNewYnabData}>
        {this.renderLayoutComponents()}
      </Layout>
    );
  }
}
