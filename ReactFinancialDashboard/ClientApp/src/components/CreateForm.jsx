import React, { Component } from "react";

export class CreateForm extends Component {
  render() {
    return (
      <form>
        <div className="form-group">
          <label>Account</label>
          <select className="form-control" id="exampleFormControlSelect1">
            <option>Select Account</option>
            <option>2</option>
            <option>3</option>
            <option>4</option>
            <option>5</option>
          </select>
        </div>
        <div className="form-group">
          <label>Statement Date</label>
          <input
            type="date"
            className="form-control"
            id="exampleFormControlInput1"
          />
        </div>
        <div className="form-group">
          <label htmlFor="exampleFormControlInput1">Statement Balance</label>
          <input
            type="text"
            className="form-control"
            id="exampleFormControlInput1"
            placeholder="Amount"
          />
        </div>
        <div className="form-group">
          <label htmlFor="exampleFormControlInput1">Minimum Payment</label>
          <input
            type="text"
            className="form-control"
            id="exampleFormControlInput1"
            placeholder="Min. Payment"
          />
        </div>
        <div className="form-group">
          <label>Payment Due Date</label>
          <input
            type="date"
            className="form-control"
            id="exampleFormControlInput1"
          />
        </div>
      </form>
    );
  }
}
