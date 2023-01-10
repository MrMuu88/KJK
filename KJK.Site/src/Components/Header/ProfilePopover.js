import React from "react";
import { List, Box, Divider, Popover, Typography,Link, Button, ListItemText } from "@material-ui/core";
import { ListItemButton } from "@mui/material";

export default function ProfilePopover(props){
    const [anchorEl, setAnchorEl] = React.useState(null);
    const isOpen= Boolean(anchorEl);
    const openPopover = (event) =>setAnchorEl(anchorEl ? null: event.currentTarget);
    const closePopOver = (event) => setAnchorEl(null);

    return <Box>
        <Button color="inherit" onClick={openPopover}>Profile</Button>
        <Popover open={isOpen} anchorEl={anchorEl} onClose={closePopOver} anchorOrigin={{vertical:'bottom',horizontal:'right'}}>
            <ProfileBox onLogout={props.onLogout} />
        </Popover>
    </Box>;
}

function ProfileBox(props){

    return <Box >
        <Box sx={{display:'flex', p:1}}>
            <img src="logo192.png" width="100" height="100"/> {/*this will be the user profile picture stored in the database */}
            <Box>
                <Typography variant="h4">User Name</Typography>
                <Typography variant="h6">Email@address.com</Typography>
                <Link href="#">Account Settings</Link>
            </Box>
        </Box>
        <Divider/>
        <Box sx={{p:1, display:'flex', justifyContent:'center'}}>
            <Button onClick={props.onLogout}>Log out</Button>
        </Box>
        <Divider/>
            <List >
                <ListItemButton component="a" href="#">
                    <ListItemText >General terms and conditions</ListItemText>
                </ListItemButton>
                <ListItemButton component="a" href="#">
                    <ListItemText >data management guidelines</ListItemText>
                </ListItemButton>
                <ListItemButton component="a" href="#">
                    <ListItemText>FAQ</ListItemText>
                </ListItemButton>
            </List>
    </Box>
}