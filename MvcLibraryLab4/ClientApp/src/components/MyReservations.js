import React, { Component } from 'react';

export class MyReservations extends Component {
  static displayName = MyReservations.name;

  constructor(props) {
    super(props);
    this.state = { books: [], loading: true };
  }

  componentDidMount() {
    this.populateBookData();
  }

  static renderBooksTable(books) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Release Date</th>
            <th>Genre</th>
            <th>Number of Pages</th>
            <th colspan="2">Options</th>
          </tr>
        </thead>
        <tbody>
          {books.map(book=>
            <tr key={book.id}>
              <td>{book.title}</td>
              <td>{book.author}</td>
              <td>{book.releaseDate}</td>
              <td>{book.genre}</td>
              <td>{book.pagesNumber}</td>
              <td>Details</td>
              <td>Cancel</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : MyReservations.renderBooksTable(this.state.books);

    return (
      <div>
        <h1 id="tabelLabel" >My Reservations</h1>
        <p>Here you can find your book reservations.</p>
        {contents}
      </div>
    );
  }

  async populateBookData() {
    const response = await fetch('books');
    const data = await response.json();
    this.setState({ books: data, loading: false });
  }
}
