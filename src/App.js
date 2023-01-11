import logo from './logo.svg';
import './App.css';
import { useState } from 'react';
import MainNavigation from './components/layout/MainNavigation';
import Home from './components/Home';
import Library from './components/Library';
import MyAccount from './components/MyAccount';
import MyRentals from './components/MyRentals';
import MyReservations from './components/MyReservations';

function App() {
  const [tabIsOpen, setTabIsOpen] = useState('Home');

  function homeClickHandler() {
      setTabIsOpen('Home');
  }

  function libraryClickHandler() {
      setTabIsOpen('Library');
  }

  function myAccountClickHandler() {
    setTabIsOpen('MyAccount')
  }

  function myRentalsClickHandler() {
      setTabIsOpen('MyRentals');
  }

  function myReservationsClickHandler() {
      setTabIsOpen('MyReservations');
  }

  return (
    <div className="App container">
        <h2 className="d-flex justify-content-center m-3">
          NTR22Z Lab 4
        </h2>
        <MainNavigation onHomeClick={homeClickHandler} onLibraryClick={libraryClickHandler} onMyAccountClick={myAccountClickHandler} onMyRentalsClick={myRentalsClickHandler} onMyReservationsClick={myReservationsClickHandler} />
            {tabIsOpen === 'Home' && <Home/>}
            {tabIsOpen === 'Library' && <Library/>}
            {tabIsOpen === 'MyAccount' && <MyAccount />}
            {tabIsOpen === 'MyReservations' && <MyReservations />}
            {tabIsOpen === 'MyRentals' && <MyRentals/>}
       
    </div>
  );
}

export default App;
