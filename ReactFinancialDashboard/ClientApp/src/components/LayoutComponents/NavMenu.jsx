import React, { Component } from "react";
import { Link } from "react-router-dom";
import { Glyphicon, Nav, Navbar, NavItem } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import { MyButton } from "./MyButton";
import "../../css/NavMenu.css";

export class NavMenu extends Component {
  displayName = NavMenu.name;

  renderNavMenu = () => {
    let { componentsList } = this.props;
    let navMenu = [];

    for (let item in componentsList) {
      let component = componentsList[item];
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
    let { navDisplayValues, routePath } = this.props;
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={routePath}>{navDisplayValues}</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <MyButton
              buttonType={"getYnabData"}
              getYnabData={this.props.getYnabData}
            />
            {this.renderNavMenu()}
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
