import { useState } from 'react'
import MainNavigation from './components/layout/MainNavigation'
import Home from './components/Home'
import Library from './components/Library'


function App() {
    const [tabIsOpen, setTabIsOpen] = useState('Home');

    function homeClickHandler() {
        setTabIsOpen('Home');
    }

    function libraryClickHandler() {
        setTabIsOpen('Library');
    }
    return (
        <div>
            <MainNavigation onHomeClick={homeClickHandler} onLibraryClick={libraryClickHandler}/>
            {tabIsOpen == 'Home' && <Home/>}
            {tabIsOpen == 'Library' && <Library/>}
        </div>
    );
}

export default App;
