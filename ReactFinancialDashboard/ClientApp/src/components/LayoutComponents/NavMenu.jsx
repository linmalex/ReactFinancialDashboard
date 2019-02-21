import React, { Component } from "react";
import { Link } from "react-router-dom";
import { Glyphicon, Nav, Navbar, NavItem } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import { MyButton } from "./MyButton";
import "../../css/NavMenu.css";

export class NavMenu extends Component {
  displayName = NavMenu.name;

  renderNavMenu = () => {
    let { serverData } = this.props;
    let navMenu = [];

    for (let i in serverData.componentsList) {
      let component = serverData.componentsList[i];
      let linkContainer = (
        <LinkContainer key={Math.random() * 10} to={component.routePath}>
          <NavItem>
            <Glyphicon glyph={component.glyph} />
            {component.navDisplayValues}
          </NavItem>
        </LinkContainer>
      );
      navMenu.push(linkContainer);
    }
    return navMenu;
  };

  renderTempNav() {
    let routePath = "/";
    let navDisplayValue = "Component Nav Display Value";
    let glyph = "inbox";
    return (
      <LinkContainer key={Math.random() * 10} to={routePath}>
        <NavItem>
          <Glyphicon glyph={glyph} />
          {navDisplayValue}
        </NavItem>
      </LinkContainer>
    );
  }

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={"/"}>Header Value</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <MyButton
              buttonType={"getYnabData"}
              getYnabData={this.props.getYnabData}
            />
            //! temporary
            {this.renderTempNav()}
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
