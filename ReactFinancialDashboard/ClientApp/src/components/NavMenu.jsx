import React, { Component } from "react";
import { Link } from "react-router-dom";
import { Glyphicon, Nav, Navbar, NavItem } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import "../css/NavMenu.css";

export class NavMenu extends Component {
  displayName = NavMenu.name;

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={"/"}>ReactFinancialDashboard</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={"/"} exact>
              <NavItem>
                <Glyphicon glyph="home" /> Home
              </NavItem>
            </LinkContainer>
                    <LinkContainer to={"/paymentsdue"}>
                        <NavItem>
                            <Glyphicon glyph="th-list" /> Payments Due
              </NavItem>
                    </LinkContainer>
                    <LinkContainer to={"/ynabaccountbalances"} exact>
                        <NavItem>
                            <Glyphicon glyph="home" />
                            Ynab Accounts
                            </NavItem>
                    </LinkContainer>
                    <LinkContainer to={"/creditcard"} exact>
                        <NavItem>
                            <Glyphicon glyph="home" /> Credit Card
                            </NavItem>
                    </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
