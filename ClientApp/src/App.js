import React, { Component } from 'react';
import { Layout } from './Layout';
import Home from './Home';

import './custom.css'

export default class App extends Component {
  render () {
    return (
      <Layout>
        <Home />
      </Layout>
    );
  }
}
