import React, {useEffect, useState} from 'react';
import './App.css';
import axios, {AxiosResponse} from 'axios';


interface User{
   first_name: string;
   last_name: string;
   username: string;
   email: string;
   avatar: string;
   gender: string;
   phone_number: string;
   date_of_birth: string;
}



const App = () => {

  const [user, setUser] = useState<User>();

  useEffect(() => {
    axios.get('https://random-data-api.com/api/v2/users')
    .then((response: AxiosResponse) => {
        setUser( response.data );
    });
  }, []);
  
  console.log(user)

  return (
    <div className="App">
      <header className="App-header">
        <img src={user?.avatar} style={{height:"200px"}} className="App-logo" alt="logo" />

        <table id="customers">
          <tr>
            <td>First Name</td>
            <td> {user?.first_name}</td>
          </tr>
          <tr>
            <td>Last Name</td>
            <td>{user?.last_name}</td>
          </tr>
          <tr>
            <td>User Name:</td>
            <td>{user?.username}</td>
          </tr>
          <tr>
            <td>Email</td>
            <td>{user?.email}</td>
          </tr>
          <tr>
            <td>Gender</td>
            <td>{user?.gender}</td>
          </tr>
          <tr>
            <td>Phone Number</td>
            <td>{user?.phone_number}</td>
          </tr>
          <tr>
            <td>Date of birth</td>
            <td>{user?.date_of_birth}</td>
          </tr>

        </table>

      </header>
    </div>
  );
}

export default App;
