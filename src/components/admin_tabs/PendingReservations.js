import { useState, useEffect } from 'react'
import {variables} from '../../Variables.js'


function PendingReservations(props) {
    const [isLoading, setIsLoading] = useState(true);
    const [loadedBooks, setLoadedBooks] = useState([]);
    const [isBookChosen, setIsBookChosen] = useState(null);

    function rentHanlder(event) {
        event.preventDefault();     // prevent server request

        const bookData = {
            id: isBookChosen.Id,
            title: isBookChosen.Title,
            author: isBookChosen.Author,
            releaseDate: isBookChosen.ReleaseDate,
            genre: isBookChosen.Genre,
            pagesNumber: isBookChosen.PagesNumber,
            username: isBookChosen.Username,
            reservedUntil: null,
            lentUntil: (new Date()).toISOString(),
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

    function cancelHanlder(event) {
        event.preventDefault();     // prevent server request

        const bookData = {
            id: isBookChosen.Id,
            title: isBookChosen.Title,
            author: isBookChosen.Author,
            releaseDate: isBookChosen.ReleaseDate,
            genre: isBookChosen.Genre,
            pagesNumber: isBookChosen.PagesNumber,
            username: null,
            reservedUntil: null,
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
        fetch(variables.API_URL+'Book/pendingreservations').then(response => {
            return response.json();
        }).then(data => {
            setIsLoading(false);
            setLoadedBooks(data);
        });
    }, [props.getAdminUsername()]); // condition to execute useEffect - no dependencies -> this will be executed only once

    if (props.getAdminUsername() == null) {
        return (
            <section>
                <h2>Pending Reservations</h2>
                <p>We are sorry to say that but you need to log in before viewing this content.</p>
            </section>
        )
    }

    if (isLoading) {
        return (
            <section>
                <h2>Pending Reservations</h2>
                <p>All book reservation data is loading. Please wait.</p>
            </section>
        )
    }

    return (
        <div>
            <h2>Pending Reservations</h2>
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Author</th>
                        <th>Release Date</th>
                        <th>Genre</th>
                        <th>Number of Pages</th>
                        <th>Reserved Until</th>
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
                                <td>{book.ReservedUntil}</td>
                                <td>
                                    <button className="btn btn-light mr-1" onMouseEnter={() => setIsBookChosen(book)} onClick={rentHanlder}>Rent</button>
                                    <button className="btn btn-light mr-1" onMouseEnter={() => setIsBookChosen(book)} onClick={cancelHanlder}>Cancel</button>
                                </td>
                            </tr>
                        )
                     })}
                </tbody>
            </table>
        </div>
    );
}

export default PendingReservations;
