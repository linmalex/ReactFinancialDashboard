import React, { Component } from "react";

export class Statement extends Component {
    render() {
        var statement = this.props.statement;
        return (
                <tr key={statement.ID}>
                    <td>{statement.IssueDate}</td>
                    <td>{statement.DueDate}</td>
                    <td>{statement.Balance}</td>
                    <td>{statement.MinPayment}</td>
                </tr>
                )
            ;
    }
}