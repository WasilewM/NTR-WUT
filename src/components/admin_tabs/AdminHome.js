function AdminHome(props) {
    return (
        <section>
            <h2>Hi {props.getAdminUsername()}! Nice to see you again</h2>
            <p>Pherhaps the wheater will make your day good...</p>
        </section>
    );
}

export default AdminHome;
