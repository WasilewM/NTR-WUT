import WeatherForecast from "../WeatherForecast.js"

function AdminHome(props) {
    return (
        <section>
            <h2>Hi {props.getAdminUsername()}! Nice to see you again</h2>
            <p>Perhaps the weather will make your day good...</p>
            <WeatherForecast/>
        </section>
    );
}

export default AdminHome;
