import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Bugs manager</h1>
        <p>Welcome to our bugs management system.</p>
        <p>Here you will find proper screens to support bugs assignment according to implemented web api methods:</p>
        <ul>
          <li><strong>Dashboard of all bugs</strong>. With filtering by user, project and creation date range.</li>
          <li><strong>Create new bugs</strong>. Add bugs for a project and assign to an existing user.</li>
        </ul>
        <p><small>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</small></p>
      </div>
    );
  }
}
