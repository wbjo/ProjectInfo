import React from 'react';
import { BrowserRouter, Route, Link } from 'react-router-dom'
import Project from './components/projects/project'

const Routes = () => {
    return(
        <div>
          <Route path="/" component={Project}>
          </Route>
        </div>
    );
}

export default Routes;