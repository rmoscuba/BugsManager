import React from 'react';
import Select from './Select'
import './NewBugForm.css'

class FormExample extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      selectedUser: '',
      selectedProject: '',
      description: '',
      showError:false
    };
  }

  handleUserChange = (event) => {
    this.setState({ selectedUser: event.target.value });
  };

  handleProjectChange = (event) => {
    this.setState({ selectedProject: event.target.value });
  };

  handleDescriptionChange = (event) => {
    this.setState({ description: event.target.value });
  };

  handleSubmit = async(event) => {
    event.preventDefault();
    if(this.state.selectedUser=='' || this.state.selectedProject=='' || this.state.description==''){
       await this.setState({...this.state, showError:true});
    }else{
        const data= {
            user: this.state.selectedUser,
            project: this.state.selectedProject,
            description: this.state.description
        }
        await fetch('bugs', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        this.props.updateTable();
        this.props.closeModal();
    }
  };

  render() {
    return (
        <div style={{display: 'flex', placeContent: 'center'}}>
            <div style={{ position: 'fixed', top: 0, bottom: 0, left: 0, right: 0, backgroundColor: 'rgba(0, 0, 0, 0.5)', zIndex: 100}} onClick={this.props.closeModal}>
            </div>
            <form className='new-bug-form' onSubmit={this.handleSubmit}>
                <div className='form-group'>
                    <span>Usuario:</span><Select 
                        id='users'
                        value={this.state.selectedUser}
                        onChange={this.handleUserChange}
                        options={this.props.usersList}
                        optionValue='user'
                        optionName='name'
                    />
                </div>
                <div className='form-group'>
                  <span>Proyecto:</span><Select 
                        id='projects'
                        value={this.state.selectedProject}
                        onChange={this.handleProjectChange}
                        options={this.props.projectsList}
                        optionValue='id'
                        optionName='name'
                      />
                  </div>
                <div>
                    <label htmlFor="texto">Description:</label>
                    <textarea id="text-input" rows="2" cols="50" value={this.state.description} onChange={this.handleDescriptionChange}></textarea>
                </div> 
                <div className={this.state.showError ? "error-message" : "info-message"}>Provide a user, a project and a bug description</div>
                <button className='add-button' type="submit">Send</button>
            </form>
        </div>
    );
  }
}

export default FormExample;