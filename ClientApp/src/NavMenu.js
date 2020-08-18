import React, { Component } from 'react';
import { Container, Navbar } from 'reactstrap';

export class NavMenu extends Component {
  render () {
    return (
      <header>
        <Navbar className="border-bottom">
          <Container>
            <h1>MintSoft Order</h1>
          </Container>
        </Navbar>
      </header>
    );
  }
}
