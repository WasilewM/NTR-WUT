import classes from './MainNavigation.module.css'


function MainNavigation(props) {
    return (
        <header className={classes.header}>
            <div className={classes.logo}>MvcLibraryLab4</div>
            <nav>
                <ul>
                    <li>
                        <button onClick={props.onHomeClick}>Home</button>
                    </li>
                    <li>
                        <button onClick={props.onLibraryClick}>Library</button>
                    </li>
                    <li>
                        <button onClick={props.onMyRentalsClick}>MyRentals</button>
                    </li>
                    <li>
                        <button onClick={props.onMyReservationsClick}>MyReservations</button>
                    </li>

                </ul>
            </nav>
        </header>
    );
}

export default MainNavigation;
