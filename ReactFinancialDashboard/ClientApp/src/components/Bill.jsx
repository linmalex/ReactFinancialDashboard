import React, { Component } from "react";

class Bill extends Component {
    render() {
        return (
            <div>
                <table className="table">
                    <thead>
                        <tr>
                            <th scope="col">Pay To</th>
                            <th scope="col">Category</th>
                            <th scope="col">Amount</th>
                            <th scope="col">Due</th>
                            <th scope="col">Paid Status</th>
                            <th scope="col">Type</th>
                            <th scope="col">Memo</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.bills.map(bill => (
                            <tr>
                                <td>{bill.PayTo}</td>
                                <td>{bill.Category}</td>
                                <td>{bill.Amount}</td>
                                <td>{bill.Due}</td>
                                <td>{bill.PaidStatus}</td>
                                <td>{bill.Type}</td>
                                <td>{bill.Memo}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        );
    }
}

export default Bill;
