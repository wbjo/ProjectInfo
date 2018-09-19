import React from 'react';
import TextField from '@material-ui/core/TextField';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Chip from '@material-ui/core/Chip';
import Typography from '@material-ui/core/Typography';
import './project.css';

const ProjectInfo = (props) => {
    var thirdParties = props.project.thirdParties ? 
            props.project.thirdParties.map((party, i) =>{ return <Chip key={i} label={party} className="col-4 bottom-margin chip"></Chip> }) 
            : <div></div>;

    var members = props.project.members ? props.project.members.map((member, i) => { return <div key={i}>{member}</div> }) 
                                        : <div></div>;
    return(
        <div className="flex">
            <div className="row project-box">
                <div className="col-12">
                    <TextField label="Projekt" value={props.project.name} className="col-3"></TextField>
                    <TextField label="Frontend" value={props.project.frontend} className="col-3"></TextField>
                    <TextField label="Backend" value={props.project.backend} className="col-3"></TextField>
                    <TextField label="Hosting" value={props.project.hosting} className="col-3"></TextField>
                </div>
                <div className="col-9 top-margin full-height">
                    <Typography color="textSecondary">
                        Använda tredjepartslösningar
                    </Typography>
                    <Card className="full-width full-height">
                        <CardContent>
                                
                                {  
                                    thirdParties
                                }
                                <div className="col-4">
                        
                                </div>
                        </CardContent>
                    </Card>
                </div>
                <div className="col-3 top-margin full-height">
                    <Typography color="textSecondary">
                        Medlemmar
                    </Typography>
                    <Card className="full-width full-height">
                        <CardContent>
                            {members}
                        </CardContent>
                    </Card>
                </div>
            </div>
        </div>
    );
}

export default ProjectInfo;