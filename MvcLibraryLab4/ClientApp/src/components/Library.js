const DUMMY_LIBRARY = [
    {
        id: 1,
        title: 'The Witcher Sword of Destiny',
        author: 'Andrzej Sapkowski',
        releaseDate: '01.01.1992',
        genre: 'Fantasy',
        pagesNumber: 384
    },
    {
        id: 2,
        title: 'The Witcher The Last Wish',
        author: 'Andrzej Sapkowski',
        releaseDate: '01.01.1993',
        genre: 'Fantasy',
        pagesNumber: 288
    },
    {
        id: 3,
        title: 'The Witcher Blood of Elves',
        author: 'Andrzej Sapkowski',
        releaseDate: '01.01.1994',
        genre: 'Fantasy',
        pagesNumber: 320
    },
    {
        id: 4,
        title: 'The Witcher Time of Contempt',
        author: 'Andrzej Sapkowski',
        releaseDate: '01.01.1995',
        genre: 'Fantasy',
        pagesNumber: 351
    },
    {
        id: 5,
        title: 'The Witcher Baptism of Fire',
        author: 'Andrzej Sapkowski',
        releaseDate: '01.01.1996',
        genre: 'Fantasy',
        pagesNumber: 352
    },
    {
        id: 6,
        title: 'The Witcher The Tower of the Swallow',
        author: 'Andrzej Sapkowski',
        releaseDate: '01.01.1997',
        genre: 'Fantasy',
        pagesNumber: 464
    },
    {
        id: 7,
        title: 'The Witcher The Lady of the Lake',
        author: 'Andrzej Sapkowski',
        releaseDate: '01.01.1999',
        genre: 'Fantasy',
        pagesNumber: 544
    },
    {
        id: 8,
        title: 'The Witcher Season of Storms',
        author: 'Andrzej Sapkowski',
        releaseDate: '06.11.2013',
        genre: 'Fantasy',
        pagesNumber: 384
    },
    {
        id: 9,
        title: 'The Chronicles of Narnia The Lion, The With and The Wardrobe',
        author: 'C. S. Levis',
        releaseDate: '16.10.1950',
        genre: 'Fantasy',
        pagesNumber: 200
    },
    {
        id: 10,
        title: 'The Chronicles of Narnia Prince Caspian',
        author: 'C. S. Levis',
        releaseDate: '15.10.1951',
        genre: 'Fantasy',
        pagesNumber: 195
    },
    {
        id: 11,
        title: 'The Chronicles of Narnia The Voyage of The Dawn Treader',
        author: 'C. S. Levis',
        releaseDate: '15.09.1952',
        genre: 'Fantasy',
        pagesNumber: 223
    },
    {
        id: 12,
        title: 'The Chronicles of Narnia The Lion, The Silver Chair',
        author: 'C. S. Levis',
        releaseDate: '07.09.1953',
        genre: 'Fantasy',
        pagesNumber: 217
    },
    {
        id: 13,
        title: 'The Chronicles of Narnia The Horse and His Boy',
        author: 'C. S. Levis',
        releaseDate: '06.09.1954',
        genre: 'Fantasy',
        pagesNumber: 199
    },
    {
        id: 14,
        title: 'The Chronicles of Narnia The Magician\'s Nephew',
        author: 'C. S. Levis',
        releaseDate: '02.05.1955',
        genre: 'Fantasy',
        pagesNumber: 183
    },
    {
        id: 15,
        title: 'The Chronicles of Narnia The Last Battle',
        author: 'C. S. Levis',
        releaseDate: 'Fantasy',
        genre: '04.09.1956',
        pagesNumber: 184
    },
    {
        id: 16,
        title: 'Clean Code',
        author: 'Robert C. Martin',
        releaseDate: '01.03.2009',
        genre: 'Education',
        pagesNumber: 464
    },
    {
        id: 17,
        title: 'Clean Architecture',
        author: 'Robert C. Martin',
        releaseDate: '01.09.2017',
        genre: 'Education',
        pagesNumber: 432
    }
]


function Library() {
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
                    {DUMMY_LIBRARY.map((book) => {
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
