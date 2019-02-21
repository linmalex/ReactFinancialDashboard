import React, { Component } from "react";
import { MyButton } from "./MyButton";

export class Table extends Component {
  handleFilter() {}

  renderTable() {}

  render() {
    let { columnDisplayTitles, data, jsonTitleValues } = this.props.tableData;
    var datamap;
    if (data == null) {
      datamap = <tr />;
    } else {
      datamap = data.map(item => (
        <tr key={data.indexOf(item)}>
          {jsonTitleValues.map(titleValue => (
            <td key={jsonTitleValues.indexOf(titleValue)}>
              {item[titleValue]}
            </td>
          ))}
        </tr>
      ));
    }

    return (
      <div>
        <MyButton buttonType="filter" handleFilter={this.handleFilter} />
        <table className="table">
          <thead>
            <tr>
              {columnDisplayTitles.map(title => (
                <td key={columnDisplayTitles.indexOf(title)}>{title}</td>
              ))}
            </tr>
          </thead>
          <tbody>{datamap}</tbody>
        </table>
      </div>
    );
  }
}
