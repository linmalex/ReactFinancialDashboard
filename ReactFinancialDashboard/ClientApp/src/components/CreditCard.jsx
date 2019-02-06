import React, { Component } from "react";

export class CreditCard extends Component {
    static renderfulltable(creditCards) {
        return (
            <table className="table">
                <thead>
                    <tr>
                        <th>Account Name</th>
                        <th>Statement Date</th>
                        <th>Payment Due Date</th>
                        <th>Statement Balance</th>
                        <th>Minimum Payment</th>
                        <th>YNAB Account Balance</th>
                    </tr>
                </thead>
                <tbody>
                    {creditCards.map(creditCard => (
                        <tr key={creditCard.ID}>
                            <td>{creditCard.name}</td>
                            <td>{creditCard.IssueDate}</td>
                            <td>{creditCard.DueDate}</td>
                            <td>{creditCard.Balance}</td>
                            <td>{creditCard.MinPayment}</td>
                            <td>{creditCard.balance}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        );
    }

    constructor(props) {
        super(props);
        this.state = { creditCards: [], loading: true };

        this.getCreditCards();
    }

    getCreditCards = () => {
        fetch('api/YNABCreditCard/FullCreditCardData')
            .then(response => response.json())
            .then(data => {
                var x = data["data"]["accounts"];
                console.log(x);
                this.setState({ accounts: x, loading: false });
            });
    }


    getServerStatements = () => {
        fetch('api/YNABCreditCard/ServerStatements')
            .then(response => response.json())
            .then(data => {
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