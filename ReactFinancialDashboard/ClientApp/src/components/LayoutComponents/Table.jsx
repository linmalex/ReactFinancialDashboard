import React, { Component } from "react";

export class Table extends Component {
  state = {};

  render() {
    // var statements = { titles: thTitles, data: data };
    const tableData = this.props.data;
    return (
      <table className="table">
        <thead>
          <tr>
            {tableData.titles.map(title => (
              <th>{title}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {tableData.data.map(statement => (
            <tr key={statement.ID}>
              <td>{statement.IssueDate}</td>
              <td>{statement.DueDate}</td>
              <td>{statement.Balance}</td>
              <td>{statement.MinPayment}</td>
              <td>{statement.PaidStatus}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }
}
