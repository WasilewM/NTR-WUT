import React, { Component } from 'react';


export class BookDetails extends Component {
    static displayName = BookDetails.name;

    constructor(props) {
        super(props);
        this.state = { books: [], loading: true };
    }

    render() {
        return (
            <div>
                <h1 id="tabelLabel" >Book Deatils</h1>
                <p></p>
            </div>
        );
    }
}