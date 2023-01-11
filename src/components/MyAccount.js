import { useRef } from 'react'
import {variables} from '../Variables.js'


function MyAccount(props) {
    const usernameInputRef = useRef();
    const firstnameInputRef = useRef();
    const lastnameInputRef = useRef();
    const passwordInputRef = useRef();
    const credentialsUsernameInputRef = useRef();
    const credentialsPasswordInputRef = useRef();

    function createAccountHandler(event) {
        event.preventDefault();     // prevent server request

        const newAccountData = {
            username: usernameInputRef.current.value,
            firstname: firstnameInputRef.current.value,
            lastname: lastnameInputRef.current.value,
            password: passwordInputRef.current.value
        }


        fetch(variables.API_URL+"User", {
            method: "POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(newAccountData)
        })
        .then(res => res.json())
        .then((result) => {
            if (result === true) {
                alert("Success");
            }
            else {
                alert("Failure");
            }
        })
    }

    function logInHandler(event) {
        event.preventDefault();     // prevent server request

        const credentialsData = {
            username: credentialsUsernameInputRef.current.value,
            password: credentialsPasswordInputRef.current.value
        }


        fetch(variables.API_URL+"User/login", {
            method: "POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(credentialsData)
        })
        .then(res => res.json())
        .then((result) => {
            if (result === true) {
                alert("Success");
                variables.USERNAME = credentialsUsernameInputRef.current.value;
                console.log(variables.USERNAME);
            }
            else {
                alert("Failure");
            }
        })
    }
    


    return (
        <section>
            <h2>MyAccount</h2>

            <button className="btn btn-primary m-2 float-start" data-bs-toggle="modal" data-bs-target="#CreateAccountModal">
                Create Account
            </button>
            <button className="btn btn-primary m-2 float-start" data-bs-toggle="modal" data-bs-target="#LogInModal">
                Log in
            </button>

            {/* @TODO: Extract modal to separate file if time allows */}
            <div className="modal fade" id="CreateAccountModal" tabIndex="-1" aria-hidden="true">
                <div className="modal-dialog modal-lg modal-dialog-centered">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Please, provide your data</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                             <form onSubmit={createAccountHandler}>
                                <div className="input-group mb-3">
                                    <label className="input-group-text" htmlFor='username'>Username</label>
                                    <input type='text' className="form-control" required id='username' ref={usernameInputRef}/>
                                </div>
                                <div className="input-group mb-3">
                                    <label className="input-group-text" htmlFor='firstname'>First Name</label>
                                    <input type='text' className="form-control" required id='firstname' ref={firstnameInputRef}/>
                                </div>
                                <div className="input-group mb-3">
                                    <label className="input-group-text" htmlFor='lastname'>Last Name</label>
                                    <input type='text' className="form-control" required id='lastname' ref={lastnameInputRef}/>
                                </div>
                                <div className="input-group mb-3">
                                    <label className="input-group-text" htmlFor='password'>Password</label>
                                    <input type='password' className="form-control" required id='password' ref={passwordInputRef}/>
                                </div>
                                <div>
                                    <button className="btn btn-primary float-start">Create Account</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>    
            </div>

            {/* @TODO: Extract modal to separate file if time allows */}
            <div className="modal fade" id="LogInModal" tabIndex="-1" aria-hidden="true">
                <div className="modal-dialog modal-lg modal-dialog-centered">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Please, provide your credentials</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                             <form onSubmit={logInHandler}>
                                <div className="input-group mb-3">
                                    <label className="input-group-text" htmlFor='username'>Username</label>
                                    <input type='text' className="form-control" required id='username' ref={credentialsUsernameInputRef}/>
                                </div>
                                <div className="input-group mb-3">
                                    <label className="input-group-text" htmlFor='password'>Password</label>
                                    <input type='password' className="form-control" required id='password' ref={credentialsPasswordInputRef}/>
                                </div>
                                <div>
                                    <button className="btn btn-primary float-start">Log in</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>    
            </div>
        </section>
    );
}

export default MyAccount;
