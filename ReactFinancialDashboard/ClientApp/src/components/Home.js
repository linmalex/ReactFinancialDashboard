import React, { Component } from "react";

export class Home extends Component {
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
                        <tr key={account.id}>
                            <td>{account.name}</td>
                            <td>{account.balance}</td>
                        </tr>
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
        fetch('api/YnabAccount/YNABAccountsJson')
            .then(response => response.json())
            .then(data => {
                var x = data["data"]["accounts"];
                console.log(x);
                this.setState({ accounts: x, loading: false });
            });
    }

    getStatementData = () => {
        fetch('api/YnabAccount/YNABAccountsJson')
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
            : Home.renderAccountsTable(this.state.accounts);

        return (
            <div>
                <h1>Credit Cards</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}
