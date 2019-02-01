import React, { Component } from 'react';

export class YnabTransaction extends Component {
    static renderTransactionsTable(transactions) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {transactions.map(forecast =>
                        (<tr key={forecast.dateFormatted}>
                            <td>{forecast.dateFormatted}</td>
                            <td>{forecast.temperatureC}</td>
                            <td>{forecast.temperatureF}</td>
                            <td>{forecast.summary}</td>
                        </tr>)
                    )}
                </tbody>
            </table>
        );
    }
    constructor(props) {
        super(props);
        this.state = { transactions: [], loading: true };

        fetch('api/SampleData/WeatherForecasts')
            .then(response => response.json())
            .then(data => {
                this.setState({ transactions: data, loading: false });
            });
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderTransactionsTable(this.state.transactions);

        return (
            <div>
                <h1>Transactions</h1>
                {contents}
            </div>
        );
    }
}