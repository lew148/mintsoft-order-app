import React, { Component } from 'react';
import { Layout } from './Layout';
import Home from './Home';

export default class App extends Component {
    render() {
        return (
            <Layout>
                <div className="d-flex card-container">
                    <Home />
                </div>
            </Layout>
        );
    }
}