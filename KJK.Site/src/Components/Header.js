import React from "react";
import { AppBar, Box, Button, Toolbar, Typography} from "@material-ui/core";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";

export default function Header(props){
    return(
        <AppBar position="static">
            <Toolbar>
                <IconButton size="large" edge="start" color="inherit" aria-label="menu" sx={{mr:2}}>
                    <MenuIcon onClick={props.openMenu}/>
                </IconButton>

                <Typography variant="h6" component="div" sx={{flexGrow:1}}>
                    KJK Site
                </Typography>
                <Box anchor="right">
                    <Button color="inherit" edge="end">login</Button>
                    <Button color="inherit" edge="end">Register</Button>
                </Box>
            </Toolbar>
        </AppBar>
    );
}