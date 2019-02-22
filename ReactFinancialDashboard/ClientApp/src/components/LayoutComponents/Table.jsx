import React, { Component } from "react";
import { MyButton } from "./MyButton";

export class Table extends Component {
  handleFilter() {}

  renderTable() {
    let { data, jsonTitleValues } = this.props.tableData;
    var datamap;

    const formatter = new Intl.NumberFormat("en-US", {
      style: "currency",
      currency: "USD",
      minimumFractionDigits: 2
    });

    if (data == null) {
      datamap = <tr />;
    } else {
      datamap = data.map(item => (
        <tr key={data.indexOf(item)}>
          {jsonTitleValues.map(titleValue => (
            <td key={jsonTitleValues.indexOf(titleValue)}>
              {typeof item[titleValue] === "number"
                ? formatter.format(item[titleValue])
                : item[titleValue]}
            </td>
          ))}
        </tr>
      ));
    }
    return datamap;
  }

  render() {
    let { columnDisplayTitles } = this.props.tableData;
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
          <tbody>{this.renderTable()}</tbody>
        </table>
      </div>
    );
  }
}
