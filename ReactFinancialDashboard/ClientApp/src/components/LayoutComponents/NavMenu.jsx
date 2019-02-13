import React, { Component } from "react";
import { Link } from "react-router-dom";
import { Glyphicon, Nav, Navbar, NavItem } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import "../../css/NavMenu.css";

export class NavMenu extends Component {
  displayName = NavMenu.name;

  renderNavMenu = () => {
    var navMenu = this.props.navMenu.navMenuItems.map(item => (
      <LinkContainer key={Math.random() * 10} to={item.toValue}>
        <NavItem>
          <Glyphicon glyph={item.glyph} />
          {item.displayValues}
        </NavItem>
      </LinkContainer>
    ));
    return navMenu;
  };

  render() {
    let { navMenuHeader } = this.props.navMenu;
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={navMenuHeader.toValue}>
              {navMenuHeader.displayValues}
            </Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>{this.renderNavMenu()}</Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
