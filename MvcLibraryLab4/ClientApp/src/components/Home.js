import CreateNewAccount from "./CreateNewAccount";
import Login from "./Login";

function Home() {
    return (
        <section>
            <h1>The Home page.</h1>
            <p>Here is some home page description</p>
            <Login/>
            <CreateNewAccount/>
        </section>
    );
}

export default Home;
