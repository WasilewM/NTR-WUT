import { useState, useEffect } from 'react'
import {variables} from '../Variables.js'


function MyRentals(props) {
    const [isLoading, setIsLoading] = useState(true);
    const [loadedBooks, setLoadedBooks] = useState([]);

    useEffect(() => {
        setIsLoading(true);
        fetch(variables.API_URL+'Book/myrentals/'+props.getUsername()).then(response => {
            return response.json();
        }).then(data => {
            setIsLoading(false);
            setLoadedBooks(data);
        });
    }, [props.getUsername()]); // condition to execute useEffect - no dependencies -> this will be executed only once

    if (props.getUsername() == null) {
        return (
            <section>
                <h2>MyRentals</h2>
                <p>We are sorry to say that but you need to log in before viewing this content.</p>
            </section>
        )
    }

    if (isLoading) {
        return (
            <section>
                <h2>The Library</h2>
                <p>The Library data is loading. Please wait.</p>
            </section>
        )
    }

    return (
        <div>
            <h2>The Library</h2>
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Author</th>
                        <th>Release Date</th>
                        <th>Genre</th>
                        <th>Number of Pages</th>
                        <th>Options</th>
                    </tr>
                </thead>
                <tbody>
                    {loadedBooks.map((book) => {
                        return(
                            <tr key={book.Id}>
                                <td>{book.Title}</td>
                                <td>{book.Author}</td>
                                <td>{book.ReleaseDate}</td>
                                <td>{book.Genre}</td>
                                <td>{book.PagesNumber}</td>
                                <td>
                                    <button className="btn btn-light mr-1">Details</button>
                                    <button className="btn btn-light mr-1">Cancel</button>
                                </td>
                            </tr>
                        )
                     })}
                </tbody>
            </table>
        </div>
    );
}

export default MyRentals;
