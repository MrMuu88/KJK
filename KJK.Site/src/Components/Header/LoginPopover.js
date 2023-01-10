import React from 'react';
import { Button,Popover, Tab, Tabs,Box,TextField} from '@material-ui/core';

import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";

export default function LogInPopover(props){
    const [anchorEl,setAncorEl] = React.useState(null);
    const [tabIndex,setTabIndex] = React.useState(0);
    const isOpen = Boolean(anchorEl);

    const openPopover = (event) =>setAncorEl(anchorEl ? null: event.currentTarget); 

    const closePopover = (event) => setAncorEl(null);
    const handletabChange = (event,newIndex) => setTabIndex(newIndex);

    return <Box>
        <Button color="inherit" onClick={openPopover}>
            Login
        </Button>
        <Popover open={isOpen} anchorEl={anchorEl} onClose={closePopover} anchorOrigin={{vertical:'bottom',horizontal:'right'}}>
            <Tabs value={tabIndex} onChange={handletabChange}>
                <Tab label="Sign in"/>
                <Tab label='Register'/>
            </Tabs>
            <>
                {tabIndex === 0 &&(
                   <LoginBox onLogin={props.onLogin}/>
                )}
                {tabIndex === 1 &&(
                     <RegisterBox onRegister={props.onRegister}/>
                )}
            </>
        </Popover>
    </Box>

}

function LoginBox(props){
    return <Box sx={{display:'flex', flexDirection:'column', p:2 ,bgcolor: 'background.paper'}}>                
        <TextField id="loginName" label="login Name" variant='standard' />
        <TextField id="password" label="Password" variant='standard' type='password'/>
        <Box sx={{m:2, justifyContent:'center'}}>
            <Button onClick={props.onLogin}>Login</Button>
        </Box>
    </Box>
};

function RegisterBox(props){
    const [birthDate,setBirthDate] = React.useState(null);

    return <Box sx={{display:'flex', flexDirection:'column', p:2 ,bgcolor: 'background.paper'}}>                
        <TextField id="loginName" label="login Name" variant='standard' />
        <TextField id="email" label="E-mail" variant='standard'/>
        <TextField id="password" label="Password" variant='standard' type='password'/>
        <TextField id="password2" label="Password again" variant='standard' type='password'/>
        <LocalizationProvider dateAdapter={AdapterDayjs}>
            <DatePicker label="BirthDate" value={birthDate} onChange={(newvalue) => setBirthDate(newvalue)} renderInput={(params) => <TextField {...params}/>}/>
        </LocalizationProvider>
        <Box sx={{m:2, justifyItems:'center'}}>
            <Button onClick={props.onRegister}>Register</Button>
        </Box>
    </Box>;
}

