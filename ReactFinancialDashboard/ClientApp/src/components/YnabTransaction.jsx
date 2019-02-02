import React, { Component } from 'react';
import YnabTransaction from './YnabTransactions.jsx';

export class YnabTransactions extends Component {
    render() {
        return <YnabTransaction bills={this.state.bills} />;
    }
}