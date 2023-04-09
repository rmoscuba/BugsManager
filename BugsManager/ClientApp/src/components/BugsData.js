import React, { Component } from 'react';
import Filters from './Filters.js';
import NewBugForm from './NewBugForm.js'

export class BugsData extends Component {
  static displayName = BugsData.name;

  constructor(props) {
    super(props);
    this.state = { bugs: [], loading: true, usersList:[], projectsList:[], startDate:'2012-12-12', endDate:'', userId:'', projectId:'', open:false };
  }

  componentDidMount() {
    this.populateUsersData();
    this.populateProjectsData();
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
          { bugs!=undefined && bugs.length>0 && bugs.map(bug =>
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
      : <>
      <Filters 
        usersList={this.state.usersList} 
        projectsList={this.state.projectsList} 
        updateStartDate={this.updateStartDate}
        updateEndDate={this.updateEndDate}
        updateUserId={this.updateUserId}
        updateProjectId={this.updateProjectId}
        startDateValue={this.state.startDate}
        endDateValue={this.state.endDate}
        userIdValue={this.state.userId}
        projectIdValue={this.state.projectId}
      />
      <button className='add-button' onClick={this.changeModal} >Add new bug</button>
      {BugsData.renderBugsTable(this.state.bugs)}
      </>;

    return (
      <div>
        {this.state.open && <NewBugForm updateTable={this.populateBugsData} closeModal={this.changeModal} usersList={this.state.usersList} projectsList={this.state.projectsList}/>}
        <h1 id="tabelLabel">Dashboard of all bugs</h1>
        <p>Here find the list of all the bugs in the bugs manager.</p>
        {contents}
      </div>
    );
  }

  changeModal=()=>{
    this.setState({...this.state, open:!this.state.open})
  }

  updateStartDate=async (event)=>{
    console.log(event.target.value)
    await this.setState({...this.state, startDate:event.target.value})
    this.populateBugsData();
  }

  updateEndDate=async (event)=>{
    await this.setState({...this.state, endDate:event.target.value})
    this.populateBugsData();
  }

  updateUserId=async (event)=>{
    await this.setState({...this.state, userId:event.target.value})
    this.populateBugsData();
  }

  updateProjectId=async (event)=>{
    await this.setState({...this.state, projectId:event.target.value})
    this.populateBugsData();
  }

  async populateUsersData() {
    const response = await fetch('users/');
    const data = await response.json();
    this.setState({...this.state,  usersList: data.users });
  }

  async populateProjectsData() {
    const response = await fetch('projects/');
    const data = await response.json();
    this.setState({...this.state,  projectsList: data.projects });
  }

   populateBugsData=async()=> {
    let request='bugs';
    if(this.state.startDate!=''){
      request+='?start_date='+this.state.startDate;
    }
    if(this.state.endDate!=''){
      request+=!request.includes('?')?'?end_date='+this.state.endDate:'&end_date='+this.state.endDate;
    }
    if(this.state.userId!=''){
      request+=!request.includes('?')?'?user_id='+this.state.userId:'&user_id='+this.state.userId;
    }
    if(this.state.projectId!=''){
      request+=!request.includes('?')?'?project_id='+this.state.projectId:'&project_id='+this.state.projectId;
    }
    const response = await fetch(request);
    if(response.ok){
      const data = await response.json();
      this.setState({...this.state,  bugs: data.bugs, loading: false });
    }else{
      this.setState({...this.state,  bugs: [], loading: false });
    }
  }
}
