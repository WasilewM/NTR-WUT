function MainNavigation(props) {
    return (
        <header>
            <nav className="navbar navbar-expand-sm bg-light navbar-dark">
                <ul className="navbar-nav">
                    <li className="nav-item- m-1">
                        <button className="btn btn-light btn-outline-primary" onClick={props.onHomeClick}>Home</button>
                    </li>
                    <li className="nav-item- m-1">
                        <button className="btn btn-light btn-outline-primary" onClick={props.onLibraryClick}>Library</button>
                    </li>
                    <li className="nav-item- m-1">
                        <button className="btn btn-light btn-outline-primary" onClick={props.onMyAccountClick}>MyAccount</button>
                    </li>
                    <li className="nav-item- m-1">
                        <button className="btn btn-light btn-outline-primary" onClick={props.onMyReservationsClick}>MyReservations</button>
                    </li>
                    <li className="nav-item- m-1">
                        <button className="btn btn-light btn-outline-primary" onClick={props.onMyRentalsClick}>MyRentals</button>
                    </li>
                </ul>
            </nav>
        </header>
    );
}

export default MainNavigation;
