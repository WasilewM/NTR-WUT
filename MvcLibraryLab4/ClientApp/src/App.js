import { useState } from 'react'
import MainNavigation from './components/layout/MainNavigation'
import Home from './components/Home'
import Library from './components/Library'
import MyRentals from './components/MyRentals'
import MyReservations from './components/MyReservations'


function App() {
    const [tabIsOpen, setTabIsOpen] = useState('Home');

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

    return (
        <div>
            <MainNavigation onHomeClick={homeClickHandler} onLibraryClick={libraryClickHandler} onMyRentalsClick={myRentalsClickHandler} onMyReservationsClick={myReservationsClickHandler} />
            {tabIsOpen == 'Home' && <Home/>}
            {tabIsOpen == 'Library' && <Library/>}
            {tabIsOpen == 'MyRentals' && <MyRentals/>}
            {tabIsOpen == 'MyReservations' && <MyReservations />}
        </div>
    );
}

export default App;
