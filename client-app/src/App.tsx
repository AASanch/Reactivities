import React, { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";
import {
  AppBar,
  Typography,
  Toolbar,
  Box,
  List,
  ListItem,
} from "@mui/material";

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    const doGetActivities = async () => {
      const response = await axios.get("http://localhost:5000/api/activities");
      setActivities(response.data);
    };
    doGetActivities();
  }, []);

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Reactivities
          </Typography>
        </Toolbar>
      </AppBar>

      <List>
        {activities.map((activity: any) => {
          return <ListItem key={activity.id}>{activity.title}</ListItem>;
        })}
      </List>
    </Box>
  );
}

export default App;
