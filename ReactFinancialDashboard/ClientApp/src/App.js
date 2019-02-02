import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import ListOfBills from './components/ListOfBills';
import { YnabTransactions } from './components/YnabTransactions';


export default class App extends Component {
    displayName = App.name

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/fetchdata' component={FetchData} />
                <Route path='/listofbills' component={ListOfBills} />
                <Route path='/ynabtransactions' component={YnabTransactions} />
            </Layout>
        );
    }
}
