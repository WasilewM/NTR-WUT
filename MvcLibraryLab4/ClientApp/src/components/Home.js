import CreateNewAccount from "./CreateNewAccount";
import Login from "./Login";

function Home() {
    function createNewAccountHandler(newAccountData) {
        fetch('');    // allows to send HTTP requests
    }

    return (
        <section>
            <h1>The Home page.</h1>
            <p>Here is some home page description</p>
            <Login/>
            <CreateNewAccount onCreateNewAccount={createNewAccountHandler}/>
        </section>
    );
}

export default Home;
