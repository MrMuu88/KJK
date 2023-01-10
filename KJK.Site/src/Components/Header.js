import React from "react";
import { AppBar, Box, Button, Toolbar, Typography} from "@material-ui/core";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";
import { Stack } from "@mui/system";
import LoginPopover from "./LoginPopover";

export default function Header(props){
    return(
        <AppBar position="static">
            <Toolbar style={{display:'flex', justifyContent:'space-between'}}>
                <Stack direction='row' alignItems='center'>
                    <IconButton onClick={props.openMenu} edge="start" size="large" color="inherit" aria-label="menu" >
                        <MenuIcon />
                    </IconButton>
                    <Typography variant="h6">
                        KJK Site
                    </Typography>
                </Stack>
                <LoginPopover/>
            </Toolbar>
        </AppBar>
    );
}