import { useState, useEffect } from 'react'
import {variables} from '../Variables.js'



function Library() {
    const [isLoading, setIsLoading] = useState(true);
    const [loadedBooks, setLoadedBooks] = useState([]);

    useEffect(() => {
        setIsLoading(true);
        fetch(variables.API_URL+'Book').then(response => {
            return response.json();
        }).then(data => {
            setIsLoading(false);
            setLoadedBooks(data);
        });
    }, []); // condition to execute useEffect - no dependencies -> this will be executed only once

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
                                    <button className="btn btn-light mr-1">Reserve</button>
                                </td>
                            </tr>
                        )
                     })}
                </tbody>
            </table>
        </div>
    );
}

export default Library;
