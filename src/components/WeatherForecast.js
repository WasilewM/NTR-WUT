import { useState, useEffect } from 'react'
import {variables} from '../Variables.js'


function WeatherForecast() {
    const [isLoading, setIsLoading] = useState(true);
    const [loadedForecasts, setloadedForecasts] = useState([]);

    useEffect(() => {
        setIsLoading(true);
        fetch(variables.API_URL+'WeatherForecast').then(response => {
            return response.json();
        }).then(data => {
            setIsLoading(false);
            setloadedForecasts(data);
        });
    }, []); // condition to execute useEffect - no dependencies -> this will be executed only once

    if (isLoading) {
        return (
            <section>
                <p>Something clouds our judgement... We need to think about it a little longer</p>
            </section>
        )
    }

    return (
        <div>
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {loadedForecasts.map(forecast =>
                        <tr key={forecast.Date}>
                        <td>{forecast.Date}</td>
                        <td>{forecast.TemperatureC}</td>
                        <td>{forecast.TemperatureF}</td>
                        <td>{forecast.Summary}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
}

export default WeatherForecast;
