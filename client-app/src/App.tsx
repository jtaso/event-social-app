import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {

  // useState hook: variable to store states, function to set state
  const [activities, setActivities] = useState([]);

  // fetct activities from api server
  // axios.get() returns a promise
  // add an empty array (array of dependencies) prevent endless loop of re-render
  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').then(response => {
      console.log(response);
      setActivities(response.data);
    })
  }, []);

  return (
    <div>
      <Header as='h2' icon='users' content='REACTIVITIES'></Header>
      <List>
        {activities.map((activity: any) => (
          <List.Item key={activity.id}>
            {activity.title}
          </List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
