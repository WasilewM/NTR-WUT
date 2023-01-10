import { useState, useEffect } from 'react'



function Library() {
    const [isLoading, setIsLoading] = useState(true);
    const [loadedBooks, setLoadedBooks] = useState([]);

    useEffect(() => {
        setIsLoading(true);
        fetch('books').then(response => {
            return response.json();
        }).then(data => {
            setIsLoading(false);
            setLoadedBooks(data);
        });
    }, []); // condition to execute useEffect - no dependencies -> this will be executed only once

    if (isLoading) {
        return (
            <section>
                <h1>The Library</h1>
                <p>The Library data is loading. Please wait.</p>
            </section>
        )
    }

    return (
        <section>
            <h1>The Library</h1>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Author</th>
                        <th>Release Date</th>
                        <th>Genre</th>
                        <th>Number of Pages</th>
                        <th colspan="2">Options</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {loadedBooks.map((book) => {
                        return(
                            <tr key={book.id}>
                                <td>{book.title}</td>
                                <td>{book.author}</td>
                                <td>{book.releaseDate}</td>
                                <td>{book.genre}</td>
                                <td>{book.pagesNumber}</td>
                                <td>Details</td>
                                <td>Reserve</td>
                            </tr>
                        )
                     })}
                </tbody>
            </table>
            
        </section>
    );
}

export default Library;
