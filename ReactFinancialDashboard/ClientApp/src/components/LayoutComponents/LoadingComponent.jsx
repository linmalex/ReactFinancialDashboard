import React, { Component } from "react";
// import { Table } from "./Table";
import ReactDOM from "react-dom";
import Button from "@material-ui/core/Button";
import Paper from "@material-ui/core/Paper";
import Typography from "@material-ui/core/Typography";

export class LoadingComponent extends Component {
  render() {
    let contents = this.props.loadingData.dataLoading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      //  <Table tableData={this.props.tableData} />
      <Paper>Hello</Paper>
    );

    return (
      <div>
        <h1>{this.props.loadingData.pageTitle}</h1>
        {contents}
      </div>
    );
  }
}
