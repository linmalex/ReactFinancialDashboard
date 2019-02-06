import React, { Component } from "react";

export class PaymentsDue extends Component {
    static renderStatementsTable(statements) {
        return (
            <table className="table">
                <thead>
                    <tr>
                        <th>Statement Date</th>
                        <th>Payment Due Date</th>
                        <th>Statement Balance</th>
                        <th>Minimum Payment</th>
                    </tr>
                </thead>
                <tbody>
                    {statements.map(statement => (
                        <tr key={statement.ID}>
                            <td>{statement.IssueDate}</td>
                            <td>{statement.DueDate}</td>
                            <td>{statement.Balance}</td>
                            <td>{statement.MinPayment}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        );
    }

    constructor(props) {
        super(props);
        this.state = { accounts: [], loading: true };

        this.getServerStatements();
    }

    getServerStatements = () => {
        fetch('api/YNABCreditCard/ServerStatements')
            .then(response => response.json())
            .then(data => {
                var zero = data[0];
                console.log(zero);
                this.setState({ accounts: data, loading: false });
            });
    };


    render() {
        let contents = this.state.loading ? (
            <p>
                <em>Loading...</em>
            </p>
        ) : (
                PaymentsDue.renderStatementsTable(this.state.accounts)
            );

        return (
            <div>
                <h1>Credit Cards</h1>
                {contents}
            </div>
        );
    }
}
