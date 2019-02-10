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

    console.log(this.state);
  }

  render() {
    return (
      <table className="table">
        <thead>
          <tr>
            {this.state.columnDisplayTitles.map(title => (
              <td key={title.key}>{title}</td>
            ))}
          </tr>
        </thead>
        <tbody>
          {this.state.dataItemsToDisplay.map(item => (
            <tr>
              {this.state.jsonTitleValues.map(titleValue => (
                <td>{item[titleValue]}</td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
    );
  }
}
