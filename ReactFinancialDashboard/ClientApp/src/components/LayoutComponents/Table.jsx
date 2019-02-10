import React, { Component } from "react";

export class Table extends Component {
  state = {
    columnDisplayTitles: [],
    dataItemsToDisplay: [],
    jsonTitleValues: []
  };

  componentWillMount() {
    const {
      columnDisplayTitles,
      dataItemsToDisplay,
      jsonTitleValues
    } = this.props.state;

    this.setState({
      columnDisplayTitles,
      dataItemsToDisplay,
      jsonTitleValues
    });
  }

  render() {
    const {
      columnDisplayTitles,
      dataItemsToDisplay,
      jsonTitleValues
    } = this.props.state;
    console.log(this.state.columnDisplayTitles);
    return (
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
    );
  }
}
