import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

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
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderBooksTable(this.state.books);

    return (
      <div>
        <h1 id="tabelLabel" >Books List</h1>
        <p>This component demonstrates fetching data from the server.</p>
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
