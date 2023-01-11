function UserHome(props) {
    return (
        <section>
            <h2>Hi {props.getUsername()}! Nice to see you again</h2>
            <p>Pherhaps the wheater will help you choose the book...</p>
        </section>
    );
}

export default UserHome;
