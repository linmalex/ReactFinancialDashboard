import React, { Component } from "react";
import { MyButton } from "./MyButton";
import Paper from "@material-ui/core/Paper";

export class Table extends Component {
  handleFilter() {}

  renderPapers() {
    const formatter = new Intl.NumberFormat("en-US", {
      style: "currency",
      currency: "USD",
      minimumFractionDigits: 2
    });
    var { data } = this.props.tableData;
    var papers;

    data == null ? (papers = <Paper>Loading</Paper>) : console.log(typeof data);
    // : (papers = data.map(item => console.log(item)));
    // : (papers = data.map(stmt => (
    //     <Paper key={Math.random() * 10}>
    //       {Object.keys(stmt).map(k => (
    //         <p key={Math.random() * 10}>
    //           {k}:
    //           {typeof stmt[k] === "number"
    //             ? " " + formatter.format(stmt[k])
    //             : " " + stmt[k]}
    //         </p>
    //       ))}
    //     </Paper>
    // )));

    // return papers;
  }

  render() {
    return (
      <div>
        <MyButton buttonType="filter" handleFilter={this.handleFilter} />
        {this.renderPapers()}
      </div>
    );
  }
}
