import React, { Component } from "react";
import { FilterButton } from "../UtilityComponents/FilterButton";

export class Table extends Component {
  handleFilter() {
    console.log("handlefilter clicked");
  }

  render() {
    const {
      columnDisplayTitles,
      dataItemsToDisplay,
      jsonTitleValues
    } = this.props.state;

    return (
      <div>
        <FilterButton handleFilter={this.handleFilter} />
        <table className="table">
          <thead>
            <tr>
              {columnDisplayTitles.map(title => (
                <td key={columnDisplayTitles.indexOf(title)}>{title}</td>
              ))}
            </tr>
          </thead>
          <tbody>
            {dataItemsToDisplay.map(item => (
              <tr key={dataItemsToDisplay.indexOf(item)}>
                {jsonTitleValues.map(titleValue => (
                  <td key={jsonTitleValues.indexOf(titleValue)}>
                    {item[titleValue]}
                  </td>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}
