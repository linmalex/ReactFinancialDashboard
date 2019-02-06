import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { YnabAccountBalances } from "./components/YnabAccountBalances";
import { FetchData } from "./components/FetchData";
import ListOfBills from "./components/ListOfBills";

export default class App extends Component {
  displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={YnabAccountBalances} />
        <Route path="/fetchdata" component={FetchData} />
        <Route path="/listofbills" component={ListOfBills} />
      </Layout>
    );
  }
}
