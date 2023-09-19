import React, { useState } from "react";

const Login = ({ onLogin }) =>  {
  // React States
  const [errorMessages, setErrorMessages] = useState({});

  // User Login info
  const database = [
    {
      username: "user1",
      password: "pass1"
    },
    {
      username: "user2",
      password: "pass2"
    }
  ];

  const errors = {
    uname: "invalid username",
    pass: "invalid password"
  };

  const handleSubmit = (event) => {
    //Prevent page reload
    event.preventDefault();

    var { uname, pass } = document.forms[0];

    // Find user login info
    const userData = database.find((user) => user.username === uname.value);

    // Compare user info
    if (userData) {
      if (userData.password !== pass.value) {
        // Invalid password
        setErrorMessages({ name: "pass", message: errors.pass });
      } else {
        onLogin(true);
      }
    } else {
      // Username not found
      setErrorMessages({ name: "uname", message: errors.uname });
    }
  };

  // Generate JSX code for error message
  const renderErrorMessage = (name) =>
    name === errorMessages.name && (
      <div class="form-field">{errorMessages.message}</div>
    );

  // JSX code for login form
  return (
    <div class="wrapper">      
        <div class="logo">
            <img src="https://www.freepnglogos.com/uploads/telegram-logo-png-0.png" alt=""/>
        </div>
        <div class="text-center mt-4 name">
            Simple Login Form
        </div>
        <form class="p-3 mt-3" onSubmit={handleSubmit}>
            <div class="form-field d-flex align-items-center">
                <span class="far fa-user"></span>
                <input type="text" name="uname" placeholder="user1" />
                {renderErrorMessage("uname")}
            </div>
            <div class="form-field d-flex align-items-center">
                <span class="fas fa-key"></span>
                <input type="password" name="pass" placeholder="pass1" />
                {renderErrorMessage("pass")}
            </div>            
            <div className="btn mt-3">
              <input className="btn mt-3" type="submit" />
            </div>
        </form>
    </div>
  );
}

export default Login;




