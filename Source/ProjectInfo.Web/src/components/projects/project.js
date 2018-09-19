import React from 'react';
import ProjectInfo from './project-info';
import Button from '@material-ui/core/Button';
import ExpansionPanel from '@material-ui/core/ExpansionPanel';
import ExpansionPanelSummary from '@material-ui/core/ExpansionPanelSummary';
import ExpansionPanelDetails from '@material-ui/core/ExpansionPanelDetails';
import Typography from '@material-ui/core/Typography';
import axios from 'axios';


class Project extends React.Component{
    constructor(){
        super();
        this.state = {
            loaded: false,
            projects: [{projects: [], members: []}]
        };
        this.panelClick = this.panelClick.bind(this);

        axios.get('http://localhost:58410/api/project').then((response) => {
            response.data.projects.forEach((project) => { project['open']=false });
            this.setState({
                projects: response.data.projects,
                loaded: true
            });
        })
    }

    split(arr, size){
        var newArr = [];
        if(!arr)
            return newArr;

        for (var i=0; i<arr.length; i+=size) {
          newArr.push(arr.slice(i, i+size));
        }
        return newArr;
    }

    panelClick(p, event){
        if(event.target.classList[0] == "MuiButton-label-91")
            return;
        
        var projects = this.state.projects.slice();
        var panel = projects.find((x) => x == p);

        panel.open = !panel.open;
        this.setState({
            projects: projects
        });
    }

    repositoryClick(event){
        
    }

    render(){
        if(!this.state.loaded)
            return <div></div>

        var panels = this.state.projects.map((project, i) => {
            return <ExpansionPanel key={i} expanded={project.open} onClick={this.panelClick.bind(this, project)}>
                        <ExpansionPanelSummary className="panel-summary">
                            <Typography>{project.name}</Typography>
                            <Button id="repository-button" color="primary" onClick={this.repositoryClick}>Repository</Button>
                        </ExpansionPanelSummary>
                        <ExpansionPanelDetails>
                            <ProjectInfo project={this.state.projects[0]} splitFunction={this.split}></ProjectInfo>
                        </ExpansionPanelDetails>
                    </ExpansionPanel>           
        });
        return(
            <div>
                {panels}
            </div>
        );
    }
}

export default Project;