import React, { Component } from "react";

export class YnabAccountBalances extends Component {
    static renderAccountsTable(accounts) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Account Name</th>
                        <th>Account Balance</th>
                    </tr>
                </thead>
                <tbody>
                    {accounts.map(account =>
                        (<tr key={account.id}>
                            <td>{account.name}</td>
                            <td>${account.balance}</td>
                        </tr>)
                    )}
                </tbody>
            </table>
        );
    }

    constructor(props) {
        super(props);
        this.state = { accounts: [], loading: true };

        this.getYnabAccountsData();
    }

    getYnabAccountsData = () => {
        fetch('api/YNABCreditCard/YNABAccountsJson')
            .then(response => response.json())
            .then(data => {
                var x = data["data"]["accounts"];
                for (var i = 0; i < x.length; i++) {
                    x[i]['balance'] /= 1000;
                }
                this.setState({ accounts: x, loading: false });
            });
    }
    //todo
    getStatementData = () => {
        fetch('api/YNABCreditCard/CurrentStatements')
            .then(response => response.json())
            .then(data => {
                var x = data["data"]["accounts"];
                console.log(x);
                this.setState({ accounts: x, loading: false });
            });
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : YnabAccountBalances.renderAccountsTable(this.state.accounts);

        return (
            <div>
                <h1>YNAB Account Balances</h1>
                {contents}
            </div>
        );
    }
}
