import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import ListItemIcon from '@mui/material/ListItemIcon';
import InboxIcon from '@mui/icons-material/MoveToInbox';
import { ListItemButton } from '@mui/material';
import Drawer from '@mui/material/Drawer';
import React from "react";

export default function Menu(props){
   
    
    return (
        <Drawer variant="temporary" open={props.isMenuOpen} onClose={props.onClose}>
            <List>
                <ListItem>
                    <ListItemButton>
                        <ListItemIcon>
                            <InboxIcon/>
                        </ListItemIcon>
                        <ListItemText primary="Home"/>
                    </ListItemButton>
                </ListItem>
                
                <ListItem>
                    <ListItemButton>
                        <ListItemIcon>
                            <InboxIcon/>
                        </ListItemIcon>
                        <ListItemText primary="Character"/>
                    </ListItemButton>
                </ListItem>
                
                <ListItem>
                    <ListItemButton>
                        <ListItemIcon>
                            <InboxIcon/>
                        </ListItemIcon>
                        <ListItemText primary="Inventory"/>
                    </ListItemButton>
                </ListItem>
                
                <ListItem>
                    <ListItemButton>
                        <ListItemIcon>
                            <InboxIcon/>
                        </ListItemIcon>
                        <ListItemText primary="spells"/>
                    </ListItemButton>
                </ListItem>
            </List>
        </Drawer>
    );
}