import CreateNewAccount from "./CreateNewAccount";

function Home() {
    return (
        <section>
            <h2>MyAccount</h2>

            <button className="btn btn-primary m-2 float-start" data-bs-toggle="modal" data-bs-target="#CreateAccountModal">
                Create Account
            </button>

            <div className="modal fade" id="CreateAccountModal" tabIndex="-1" aria-hidden="true">
                <div className="modal-dialog modal-lg modal-dialog-centered">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Create Account</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                             <form onSubmit>
                                <div>
                                    <label htmlFor='username'>Username</label>
                                    <input type='text' required id='username' />
                                </div>
                                <div>
                                    <label htmlFor='firstname'>First Name</label>
                                    <input type='text' required id='firstname'  />
                                </div>
                                <div>
                                    <label htmlFor='lastname'>Last Name</label>
                                    <input type='text' required id='lastname'  />
                                </div>
                                <div>
                                    <label htmlFor='password'>Password</label>
                                    <input type='password' required id='password' />
                                </div>
                                <div>
                                    <button className="btn btn-light btn-outline-primary">Create Account</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>    
            </div>
        </section>
    );
}

export default Home;
