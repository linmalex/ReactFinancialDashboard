﻿import React, { Component } from "react";
import { Link } from "react-router-dom";
import { Glyphicon, Nav, Navbar, NavItem } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import "../../css/NavMenu.css";

export class NavMenu extends Component {
  displayName = NavMenu.name;

  renderNavMenu = () => {
    let { navMenuItems } = this.props.navMenu;
    let navMenu = [];
    for (let item in navMenuItems) {
      let component = navMenuItems[item];
      let container = (
        <LinkContainer key={Math.random() * 10} to={component.routePath}>
          <NavItem>
            <Glyphicon glyph={component.glyph} />
            {component.navDisplayValues}
          </NavItem>
        </LinkContainer>
      );
      navMenu.push(container);
    }
    return navMenu;
  };

  render() {
    let { navMenuHeader } = this.props.navMenu;
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={navMenuHeader.routePath}>
              {navMenuHeader.navDisplayValues}
            </Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <button onClick={this.props.getYnabData}>Get Ynab Data</button>
            {this.renderNavMenu()}
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
