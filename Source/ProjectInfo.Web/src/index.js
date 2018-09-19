import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import Routes from './router.js';
import { BrowserRouter as Router } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

ReactDOM.render(
    <App>
        <Router>
            <Routes></Routes>
        </Router>
    </App>,
    document.getElementById('root')
);
// registerServiceWorker();
