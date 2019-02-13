import React, { Component } from "react";
import { Table } from "./Table";

export class LoadingComponent extends Component {
  render() {
    let contents = this.props.state.dataLoading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      <Table state={this.props.state} />
    );

    return (
      <div>
        <h1>{this.props.state.pageTitle}</h1>
        {contents}
      </div>
    );
  }
}
