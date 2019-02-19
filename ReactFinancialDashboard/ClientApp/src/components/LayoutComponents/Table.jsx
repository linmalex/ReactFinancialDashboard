import React, { Component } from "react";
import { MyButton } from "./MyButton";

export class Table extends Component {
  handleFilter() {}

  render() {
    var x = this.props.tableData.data;

    return null;
  }
  // render() {
  //   var charlies = this.props.tableData.data;
  //   console.log(charlies);
  //   let columnDisplayTitles = this.props.tableData.columnDisplayTitles;
  //   let jsonTitleValues;
  //   return (
  //     <div>
  //       <MyButton buttonType="filter" handleFilter={this.handleFilter} />
  //       <table className="table">
  //         <thead>
  //           <tr>
  //             {columnDisplayTitles.map(title => (
  //               <td key={columnDisplayTitles.indexOf(title)}>{title}</td>
  //             ))}
  //           </tr>
  //         </thead>
  //         <tbody>
  //           {charlies.map(item => (
  //             <tr key={charlies.indexOf(item)}>
  //               {jsonTitleValues.map(titleValue => (
  //                 <td key={jsonTitleValues.indexOf(titleValue)}>
  //                   {item[titleValue]}
  //                 </td>
  //               ))}
  //             </tr>
  //           ))}
  //         </tbody>
  //       </table>
  //     </div>
  //   );
  // }
}
