import React, { Component } from "react";
import { Table } from "./Table";

export class LoadingComponent extends Component {
  render() {
    let contents = this.props.loadingData.dataLoading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      <Table tableData={this.props.tableData} />
    );

    return (
      <div>
        <h1>{this.props.loadingData.pageTitle}</h1>
        {contents}
      </div>
    );
  }
}
