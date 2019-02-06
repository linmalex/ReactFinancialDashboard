import React, { Component } from "react";

export class ProjectPlan extends Component {
  render() {
    return (
      <div>
        <h1>Project Plan</h1>
        <table className="table">
          <thead>
            <tr>
              <th>Feature</th>
              <th>Current</th>
              <th>Planned</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>Payments Due</td>
              <td>
                Lists statements stored in database that have been manually
                inserted
              </td>
              <td>
                <ul>
                  <li>Add paid vs unpaid filtering ability</li>
                </ul>
              </td>
            </tr>
            <tr>
              <td>Ynab Accounts</td>
              <td>Lists Ynab Accounts and their balances</td>
              <td>
                <ul>
                  <li>Fix formatting on balances</li>
                </ul>
              </td>
            </tr>
            <tr>
              <td>Credit Card</td>
              <td>Just shows "loading"</td>
              <td>
                <ul>
                  <li>
                    Get only credit cards from YNAB and display more details
                    from database
                  </li>
                </ul>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    );
  }
}
