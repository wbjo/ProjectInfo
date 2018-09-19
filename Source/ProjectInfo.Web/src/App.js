import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Navbar from './components/shared/navbar/navbar';
import Menu from './components/shared/menu/menu';

class App extends Component {
  render() {
    return (
      <div className="root">
        <Navbar></Navbar>
        <div className="main">
          <Menu></Menu>
          <div className="container">
            {this.props.children}
          </div>
        </div>
      </div>
    );
  }
}

export default App;
