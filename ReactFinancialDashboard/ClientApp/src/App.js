import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/LayoutComponents/Layout";
import { LoadingComponent } from "./components/LayoutComponents/LoadingComponent";
import AppBar from "@material-ui/core/AppBar";

import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import IconButton from "@material-ui/core/IconButton";
import MenuIcon from "@material-ui/icons/Menu";
import AccountCircle from "@material-ui/icons/AccountCircle";
import MenuItem from "@material-ui/core/MenuItem";
import Menu from "@material-ui/core/Menu";

export default class App extends Component {
  displayName = App.name;

  constructor(props) {
    super(props);
    this.state = {
      loading: true,
      serverData: {
        personalDataID: 2,
        controllerInstructions: {
          initialstate: { action: "SetInitialState", n: null },
          setYnabAccounts: { action: "SetYnabAccountsJson", n: 1 },
          setServerStatements: { action: "SetServerStatements", n: 0 }
        }
      }
    };

    const {
      initialstate,
      setYnabAccounts,
      setServerStatements
    } = this.state.serverData.controllerInstructions;

    this.callController(initialstate);
    this.callController(setYnabAccounts);
    this.callController(setServerStatements);
  }

  //#region //* UTILITIES -----------------------------------------------------------------------
  // description: generates URL for controller call using current state personalDataID
  createURL = controllerAction => {
    const id = this.state.serverData.personalDataID;
    const params = `?ID=${id}`;
    const url = `api/Data/${controllerAction}${params}`;
    return url;
  };

  // description: uses state serverData to generate render Route and LoadingComponents
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
  //#endregion

  //#region //* CONTROLLER Call -----------------------------------------------------------------------
  // description: call controller to update state using controllerInstructions object as parameter
  //! needs to be refactored so as not to need n parameter to know which component to update
  callController = async controllerInstructions => {
    const fetchURL = this.createURL(controllerInstructions.action);
    const response = await fetch(fetchURL);
    const data = await response.json();
    let { serverData } = this.state;
    // description: hard coded instructions for which segment of serverData needs to be updated
    controllerInstructions.n == null
      ? (serverData = data)
      : (serverData.componentsList[controllerInstructions.n].data = data);
    return this.setState({ serverData, loading: false });
  };
  //#endregion

  //#region //* RENDER -----------------------------------------------------------------------
  render() {
    // var layout;

    // this.state.loading
    //   ? (layout = <p>Loading</p>)
    //   : (layout = (
    //       <Layout appstate={this.state} getYnabData={this.callController}>
    //         {this.generateLoadingComponents()}
    //       </Layout>
    //     ));

    // return layout;
    const { auth, anchorEl } = this.state;
    const open = Boolean(anchorEl);
    return (
      <AppBar>
        {" "}
        <Toolbar>
          <IconButton color="inherit" aria-label="Menu">
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" color="inherit">
            Photos
          </Typography>
          (
          <div>
            <IconButton
              aria-owns={open ? "menu-appbar" : undefined}
              aria-haspopup="true"
              onClick={this.handleMenu}
              color="inherit"
            >
              <AccountCircle />
            </IconButton>
            <Menu
              id="menu-appbar"
              anchorEl={anchorEl}
              anchorOrigin={{
                vertical: "top",
                horizontal: "right"
              }}
              transformOrigin={{
                vertical: "top",
                horizontal: "right"
              }}
              open={open}
              onClose={this.handleClose}
            >
              <MenuItem onClick={this.handleClose}>Profile</MenuItem>
              <MenuItem onClick={this.handleClose}>My account</MenuItem>
            </Menu>
          </div>
          )
        </Toolbar>
      </AppBar>
    );
  }
  //#endregion
}
