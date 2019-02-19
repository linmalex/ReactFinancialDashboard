import React, { Component } from "react";
import { Col, Grid, Row } from "react-bootstrap";
import { NavMenu } from "./NavMenu";

export class Layout extends Component {
  displayName = Layout.name;

  render() {
    let { serverData } = this.props.appstate;
    return (
      <Grid fluid>
        <Row>
          <Col sm={3}>
            <NavMenu
              serverData={serverData}
              getYnabData={this.props.getYnabData}
            />
          </Col>
          <Col sm={9}>{this.props.children}</Col>
        </Row>
      </Grid>
    );
  }
}
