import React, { Component } from 'react';
import './Select.css'

export default class Select extends Component{
    constructor (props){
        super(props);
    }

    render(){
        return(
            <select className='select-combo' id={this.props.id} value={this.props.value} onChange={this.props.onChange}>
                <option value="">--Peek an option--</option>
                {this.props.options.map((el,i)=>(
                <option key={i} value={el[this.props.optionValue]}>{el[this.props.optionName]}</option>
                ))}
            </select>
        )
    }
}