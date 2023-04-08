import React, { Component } from 'react';

export class BugsData extends Component {
  static displayName = BugsData.name;

  constructor(props) {
    super(props);
    this.state = { bugs: [], loading: true };
  }

  componentDidMount() {
    this.populateBugsData();
  }

  static renderBugsTable(bugs) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Bug description</th>
            <th>User</th>
            <th>Project</th>
            <th>Date</th>
            <th>Time</th>
          </tr>
        </thead>
        <tbody>
          {bugs.map(bug =>
            <tr key={bug.id}>
              <td>{bug.description}</td>
              <td>{bug.userName}</td>
              <td>{bug.project}</td>
              <td>{(new Date(bug.creationDate)).toLocaleDateString()}</td>
              <td>{(new Date(bug.creationDate)).toLocaleTimeString()}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : BugsData.renderBugsTable(this.state.bugs);

    return (
      <div>
        <h1 id="tabelLabel">Dashboard of all bugs</h1>
        <p>Here find the list of all the bugs in the bugs manager.</p>
        {contents}
      </div>
    );
  }

  async populateBugsData() {
    const response = await fetch('bugs/?start_date=12-12-12');
    const data = await response.json();
    this.setState({ bugs: data.bugs, loading: false });
  }
}
