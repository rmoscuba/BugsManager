import React, { Component } from 'react';
import Select from './Select'

export default class Filters extends Component{
    constructor (props){
        super(props);
    }

    render(){
        return(
            <div className='filters'>
                <input type='date' value={this.props.startDateValue} onChange={this.props.updateStartDate} />
                <input type='date' min={this.props.startDateValue} value={this.props.endDateValue} onChange={this.props.updateEndDate} />
                <Select 
                    id='users'
                    value={this.props.userIdValue}
                    onChange={this.props.updateUserId}
                    options={this.props.usersList}
                    optionValue='user'
                    optionName='name'
                />
                 <Select 
                    id='projects'
                    value={this.props.projectIdValue}
                    onChange={this.props.updateProjectId}
                    options={this.props.projectsList}
                    optionValue='id'
                    optionName='name'
                />
            </div>
        )
    }
}