import WeatherForecast from "../WeatherForecast.js"

function UserHome(props) {
    return (
        <section>
            <h2>Hi {props.getUsername()}! Nice to see you again</h2>
            <p>Perhaps the weahter will help you choose the book?</p>
            <WeatherForecast/>
        </section>
    );
}

export default UserHome;
