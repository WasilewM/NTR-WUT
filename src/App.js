import './App.css';
import {variables} from './Variables.js'
import { useState, useRef } from 'react';
import MainNavigation from './components/layout/MainNavigation';
import UserHeaderButtons from './components/layout/UserHeaderButtons';
import VisitorHeaderButtons from './components/layout/VisitorHeaderButtons';
import VisitiorHome from './components/VisitorHome';
import Library from './components/Library';
import MyRentals from './components/user_tabs/MyRentals';
import MyReservations from './components/user_tabs/MyReservations';
import UserHome from './components/user_tabs/UserHome';
import AdminHome from './components/admin_tabs/AdminHome';
import Rentals from './components/admin_tabs/Rentals';
import PendingReservations from './components/admin_tabs/PendingReservations';
import SomethingWentWrong from './components/SomethingWentWrong';

function App() {
  // General use vars
  const [tabIsOpen, setTabIsOpen] = useState('Home');
  const [userIsLogged, setUserIsLogged] = useState(null);
  const [adminIsLogged, setAdminIsLogged] = useState(null);
  
  // Create Account vars
  const usernameInputRef = useRef();
  const firstnameInputRef = useRef();
  const lastnameInputRef = useRef();
  const passwordInputRef = useRef();

  // Log In vars
  const credentialsUsernameInputRef = useRef();
  const credentialsPasswordInputRef = useRef();

  // Admin Log In vars
  const adminUsernameInputRef = useRef();
  const adminPasswordInputRef = useRef();


  function homeClickHandler() {
      setTabIsOpen('Home');
  }

  function libraryClickHandler() {
      setTabIsOpen('Library');
  }

  function myRentalsClickHandler() {
      setTabIsOpen('MyRentals');
  }

  function myReservationsClickHandler() {
      setTabIsOpen('MyReservations');
  }

  function getUsernameHandler() {
      return userIsLogged;
  }

  function getAdminUsernameHandler() {
      return adminIsLogged;
  }

  function createAccountHandler(event) {
    event.preventDefault();     // prevent server request

    const newAccountData = {
        username: usernameInputRef.current.value,
        firstname: firstnameInputRef.current.value,
        lastname: lastnameInputRef.current.value,
        password: passwordInputRef.current.value
    }


    fetch(variables.API_URL+"User", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(newAccountData)
    })
    .then(res => res.json())
    .then((result) => {
        if (result === true) {
            alert("Success");
        }
        else {
            alert("Failure");
        }
    })
  }

  function logInHandler(event) {
    event.preventDefault();     // prevent server request

    const credentialsData = {
        username: credentialsUsernameInputRef.current.value,
        password: credentialsPasswordInputRef.current.value
    }

    fetch(variables.API_URL+"User/login", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(credentialsData)
    })
    .then(res => res.json())
    .then((result) => {
        if (result === true) {
            alert("Success");
            setUserIsLogged(credentialsUsernameInputRef.current.value);
        }
        else {
            alert("Failure");
        }
    })
  }

  function logInAsAdminHandler(event) {
    event.preventDefault();     // prevent server request

    const credentialsData = {
        username: adminUsernameInputRef.current.value,
        password: adminPasswordInputRef.current.value
    }

    fetch(variables.API_URL+"User/loginasadmin", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(credentialsData)
    })
    .then(res => res.json())
    .then((result) => {
        if (result === true) {
            alert("Success");
            setAdminIsLogged(adminUsernameInputRef.current.value);
        }
        else {
            alert("Failure");
        }
    })
  }

  function logOutHandler(event) {
    event.preventDefault();     // prevent server request
    setUserIsLogged(null);
    setAdminIsLogged(null);
  }

  if (userIsLogged === null && adminIsLogged === null) {
    return (
      <div className="App container">
        <h2 className="d-flex justify-content-center m-3">
          NTR22Z Lab 4
        </h2>
        <VisitorHeaderButtons/>
        
        <MainNavigation onHomeClick={homeClickHandler} onLibraryClick={libraryClickHandler}
          onMyRentalsClick={myRentalsClickHandler} onMyReservationsClick={myReservationsClickHandler}/>
        {tabIsOpen === 'Home' && <VisitiorHome/>}

        {tabIsOpen === 'Library' && <Library getUsername={getUsernameHandler}/>}
        {tabIsOpen === 'MyReservations' && <MyReservations getUsername={getUsernameHandler}/>}
        {tabIsOpen === 'MyRentals' && <MyRentals getUsername={getUsernameHandler}/>}

        {/* Modals */}
          {/* @TODO: Extract modal to separate file if time allows */}
          <div className="modal fade" id="CreateAccountModal" tabIndex="-1" aria-hidden="true">
              <div className="modal-dialog modal-lg modal-dialog-centered">
                  <div className="modal-content">
                      <div className="modal-header">
                          <h5 className="modal-title">Please, provide your data</h5>
                          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div className="modal-body">
                            <form>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='username'>Username</label>
                                  <input type='text' className="form-control" required id='username' ref={usernameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='firstname'>First Name</label>
                                  <input type='text' className="form-control" required id='firstname' ref={firstnameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='lastname'>Last Name</label>
                                  <input type='text' className="form-control" required id='lastname' ref={lastnameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='password'>Password</label>
                                  <input type='password' className="form-control" required id='password' ref={passwordInputRef}/>
                              </div>
                              <div>
                                  <button className="btn btn-primary float-start" onClick={createAccountHandler}>Create Account</button>
                              </div>
                          </form>
                      </div>
                  </div>
              </div>    
          </div>

          {/* @TODO: Extract modal to separate file if time allows */}
          <div className="modal fade" id="LogInModal" tabIndex="-1" aria-hidden="true">
              <div className="modal-dialog modal-lg modal-dialog-centered">
                  <div className="modal-content">
                      <div className="modal-header">
                          <h5 className="modal-title">Please, provide your credentials</h5>
                          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div className="modal-body">
                            <form>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='username'>Username</label>
                                  <input type='text' className="form-control" required id='username' ref={credentialsUsernameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='password'>Password</label>
                                  <input type='password' className="form-control" required id='password' ref={credentialsPasswordInputRef}/>
                              </div>
                              <div>
                                  <button className="btn btn-primary float-start" onClick={logInHandler}>Log in</button>
                              </div>
                          </form>
                      </div>
                  </div>
              </div>    
            </div>

          {/* @TODO: Extract modal to separate file if time allows */}
          <div className="modal fade" id="LogInAsAdminModal" tabIndex="-1" aria-hidden="true">
              <div className="modal-dialog modal-lg modal-dialog-centered">
                  <div className="modal-content">
                      <div className="modal-header">
                          <h5 className="modal-title">Please, provide your credentials</h5>
                          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div className="modal-body">
                            <form>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='username'>Username</label>
                                  <input type='text' className="form-control" required id='username' ref={adminUsernameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='password'>Password</label>
                                  <input type='password' className="form-control" required id='password' ref={adminPasswordInputRef}/>
                              </div>
                              <div>
                                  <button className="btn btn-primary float-start" onClick={logInAsAdminHandler}>Log in</button>
                              </div>
                          </form>
                      </div>
                  </div>
              </div>    
          </div>
      </div>
    );
  }

  if (userIsLogged != null && adminIsLogged === null) {
    return (
      <div className="App container">
        <h2 className="d-flex justify-content-center m-3">
          NTR22Z Lab 4
        </h2>
        <UserHeaderButtons onLogout={logOutHandler}/>
        
        <MainNavigation onHomeClick={homeClickHandler} onLibraryClick={libraryClickHandler}
          onMyRentalsClick={myRentalsClickHandler} onMyReservationsClick={myReservationsClickHandler}/>
        {tabIsOpen === 'Home'&& <UserHome getUsername={getUsernameHandler}/>}
        {tabIsOpen === 'Library' && <Library getUsername={getUsernameHandler}/>}
        {tabIsOpen === 'MyReservations' && <MyReservations getUsername={getUsernameHandler}/>}
        {tabIsOpen === 'MyRentals' && <MyRentals getUsername={getUsernameHandler}/>}

        {/* Modals */}
          {/* @TODO: Extract modal to separate file if time allows */}
          <div className="modal fade" id="CreateAccountModal" tabIndex="-1" aria-hidden="true">
              <div className="modal-dialog modal-lg modal-dialog-centered">
                  <div className="modal-content">
                      <div className="modal-header">
                          <h5 className="modal-title">Please, provide your data</h5>
                          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div className="modal-body">
                            <form>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='username'>Username</label>
                                  <input type='text' className="form-control" required id='username' ref={usernameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='firstname'>First Name</label>
                                  <input type='text' className="form-control" required id='firstname' ref={firstnameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='lastname'>Last Name</label>
                                  <input type='text' className="form-control" required id='lastname' ref={lastnameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='password'>Password</label>
                                  <input type='password' className="form-control" required id='password' ref={passwordInputRef}/>
                              </div>
                              <div>
                                  <button className="btn btn-primary float-start" onClick={createAccountHandler}>Create Account</button>
                              </div>
                          </form>
                      </div>
                  </div>
              </div>    
          </div>

          {/* @TODO: Extract modal to separate file if time allows */}
          <div className="modal fade" id="LogInModal" tabIndex="-1" aria-hidden="true">
              <div className="modal-dialog modal-lg modal-dialog-centered">
                  <div className="modal-content">
                      <div className="modal-header">
                          <h5 className="modal-title">Please, provide your credentials</h5>
                          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div className="modal-body">
                            <form>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='username'>Username</label>
                                  <input type='text' className="form-control" required id='username' ref={credentialsUsernameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='password'>Password</label>
                                  <input type='password' className="form-control" required id='password' ref={credentialsPasswordInputRef}/>
                              </div>
                              <div>
                                  <button className="btn btn-primary float-start" onClick={logInHandler}>Log in</button>
                              </div>
                          </form>
                      </div>
                  </div>
              </div>    
            </div>

          {/* @TODO: Extract modal to separate file if time allows */}
          <div className="modal fade" id="LogInAsAdminModal" tabIndex="-1" aria-hidden="true">
              <div className="modal-dialog modal-lg modal-dialog-centered">
                  <div className="modal-content">
                      <div className="modal-header">
                          <h5 className="modal-title">Please, provide your credentials</h5>
                          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div className="modal-body">
                            <form>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='username'>Username</label>
                                  <input type='text' className="form-control" required id='username' ref={adminUsernameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='password'>Password</label>
                                  <input type='password' className="form-control" required id='password' ref={adminPasswordInputRef}/>
                              </div>
                              <div>
                                  <button className="btn btn-primary float-start" onClick={logInAsAdminHandler}>Log in</button>
                              </div>
                          </form>
                      </div>
                  </div>
              </div>    
          </div>
      </div>
    )
  }

  if (userIsLogged === null && adminIsLogged != null) {
    return (
      <div className="App container">
          <h2 className="d-flex justify-content-center m-3">
            NTR22Z Lab 4
          </h2>
          <UserHeaderButtons onLogout={logOutHandler}/>

          <MainNavigation onHomeClick={homeClickHandler} onLibraryClick={libraryClickHandler}
            onMyRentalsClick={myRentalsClickHandler} onMyReservationsClick={myReservationsClickHandler}/>
          {tabIsOpen === 'Home' && <AdminHome getAdminUsername={getAdminUsernameHandler}/>}
          {tabIsOpen === 'Library' && <Library getUsername={getUsernameHandler}/>}
          {tabIsOpen === 'MyReservations' && <PendingReservations getAdminUsername={getAdminUsernameHandler}/>}
          {tabIsOpen === 'MyRentals' && <Rentals getAdminUsername={getAdminUsernameHandler}/>}

          {/* Modals */}
          {/* @TODO: Extract modal to separate file if time allows */}
          <div className="modal fade" id="CreateAccountModal" tabIndex="-1" aria-hidden="true">
              <div className="modal-dialog modal-lg modal-dialog-centered">
                  <div className="modal-content">
                      <div className="modal-header">
                          <h5 className="modal-title">Please, provide your data</h5>
                          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div className="modal-body">
                            <form>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='username'>Username</label>
                                  <input type='text' className="form-control" required id='username' ref={usernameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='firstname'>First Name</label>
                                  <input type='text' className="form-control" required id='firstname' ref={firstnameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='lastname'>Last Name</label>
                                  <input type='text' className="form-control" required id='lastname' ref={lastnameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='password'>Password</label>
                                  <input type='password' className="form-control" required id='password' ref={passwordInputRef}/>
                              </div>
                              <div>
                                  <button className="btn btn-primary float-start" onClick={createAccountHandler}>Create Account</button>
                              </div>
                          </form>
                      </div>
                  </div>
              </div>    
          </div>

          {/* @TODO: Extract modal to separate file if time allows */}
          <div className="modal fade" id="LogInModal" tabIndex="-1" aria-hidden="true">
              <div className="modal-dialog modal-lg modal-dialog-centered">
                  <div className="modal-content">
                      <div className="modal-header">
                          <h5 className="modal-title">Please, provide your credentials</h5>
                          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div className="modal-body">
                            <form>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='username'>Username</label>
                                  <input type='text' className="form-control" required id='username' ref={credentialsUsernameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='password'>Password</label>
                                  <input type='password' className="form-control" required id='password' ref={credentialsPasswordInputRef}/>
                              </div>
                              <div>
                                  <button className="btn btn-primary float-start" onClick={logInHandler}>Log in</button>
                              </div>
                          </form>
                      </div>
                  </div>
              </div>    
            </div>

          {/* @TODO: Extract modal to separate file if time allows */}
          <div className="modal fade" id="LogInAsAdminModal" tabIndex="-1" aria-hidden="true">
              <div className="modal-dialog modal-lg modal-dialog-centered">
                  <div className="modal-content">
                      <div className="modal-header">
                          <h5 className="modal-title">Please, provide your credentials</h5>
                          <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                      </div>
                      <div className="modal-body">
                            <form>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='username'>Username</label>
                                  <input type='text' className="form-control" required id='username' ref={adminUsernameInputRef}/>
                              </div>
                              <div className="input-group mb-3">
                                  <label className="input-group-text" htmlFor='password'>Password</label>
                                  <input type='password' className="form-control" required id='password' ref={adminPasswordInputRef}/>
                              </div>
                              <div>
                                  <button className="btn btn-primary float-start" onClick={logInAsAdminHandler}>Log in</button>
                              </div>
                          </form>
                      </div>
                  </div>
              </div>    
          </div>
      </div>
    );
  }

  return (
    <div className="App container">
        <h2 className="d-flex justify-content-center m-3">
          NTR22Z Lab 4
        </h2>
        
        <MainNavigation onHomeClick={homeClickHandler} onLibraryClick={libraryClickHandler}
          onMyRentalsClick={myRentalsClickHandler} onMyReservationsClick={myReservationsClickHandler}/>
        <SomethingWentWrong/>
    </div>
  );
}

export default App;
