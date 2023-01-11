import { useState, useEffect, useRef } from 'react'
import {variables} from '../Variables.js'


function Library(props) {
    const [isLoading, setIsLoading] = useState(true);
    const [loadedBooks, setLoadedBooks] = useState([]);
    const [isBookChosen, setIsBookChosen] = useState(null);

    function reserveHanlder(event) {
        event.preventDefault();     // prevent server request

        const bookData = {
            id: isBookChosen.Id,
            title: isBookChosen.Title,
            author: isBookChosen.Author,
            releaseDate: isBookChosen.ReleaseDate,
            genre: isBookChosen.Genre,
            pagesNumber: isBookChosen.PagesNumber,
            username: props.getUsername(),
            reservedUntil: (new Date()).toISOString(),
            lentUntil: isBookChosen.LentUntil,
            timeStamp: isBookChosen.TimeStamp
        }

        fetch(variables.API_URL+"book", {
            method: "PUT",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(bookData)
        })
        .then(res => res.json())
        .then((result) => {
            if (result === true) {
                alert("Success");
            }
            else {
                alert("Failure");
            }
        })
        setIsBookChosen(null);
    }

    useEffect(() => {
        setIsLoading(true);
        fetch(variables.API_URL+'Book').then(response => {
            return response.json();
        }).then(data => {
            setIsLoading(false);
            setLoadedBooks(data);
        });
    }, [props.getUsername()]); // condition to execute useEffect - no dependencies -> this will be executed only once

    if (isLoading) {
        return (
            <section>
                <h2>The Library</h2>
                <p>The Library data is loading. Please wait.</p>
            </section>
        )
    }

    if (props.getUsername() == null) {
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
                            {/* <th>Options</th> */}
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
                                        {/* <button className="btn btn-light mr-1">Details</button> */}
                                    </td>
                                </tr>
                            )
                         })}
                    </tbody>
                </table>
            </div>
        );
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
                                    {/* <button className="btn btn-light mr-1">Details</button> */}
                                    <button className="btn btn-light mr-1" onMouseEnter={() => setIsBookChosen(book)} onClick={reserveHanlder}>Reserve</button>
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
