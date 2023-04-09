import React, { Component } from 'react';

export default class Filters extends Component{
    constructor (props){
        super(props);
    }

    render(){
        return(
            <div className='filters'>
                <input type='date' value={this.props.startDateValue} onChange={this.props.updateStartDate} />
                <input type='date' min={this.props.startDateValue} value={this.props.endDateValue} onChange={this.props.updateEndDate} />
                <select id="users" value={this.props.userIdValue} onChange={this.props.updateUserId}>
                    <option value="">--Peek an option--</option>
                    {this.props.usersList.map((el,i)=>(
                    <option key={i} value={el.user}>{el.name}</option>
                    ))}
                </select>
                <select id="projects" value={this.props.projectIdValue} onChange={this.props.updateProjectId}>
                    <option value="">--Peek an option--</option>
                    {this.props.projectsList.map((el,i)=>(
                    <option key={i} value={el.id}>{el.name}</option>
                    ))}
                </select>
            </div>
        )
    }
}