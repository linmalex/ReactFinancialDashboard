import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { YnabAccountBalances } from "./components/YnabAccountBalances";
import { PaymentsDue } from "./components/PaymentsDue";
import { ProjectPlan } from "./components/ProjectPlan";
import { CreditCard } from "./components/CreditCard";


export default class App extends Component {
    displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path="/" component={ProjectPlan} />
                <Route exact path="/PaymentsDue" component={PaymentsDue} />
                <Route exact path="/ynabaccountbalances" component={YnabAccountBalances} />
                <Route exact path="/creditcard" component={CreditCard} />
            </Layout>
        );
    }
}
