import { useRef } from 'react'
import {variables} from '../Variables.js'


function Home() {
    const usernameInputRef = useRef();
    const firstnameInputRef = useRef();
    const lastnameInputRef = useRef();
    const passwordInputRef = useRef();

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
            alert("Success");
        },(error)=>{
            alert("Failed");
        })
    }


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
                                    <button className="btn btn-primary float-start" onClick={createAccountHandler}>Create Account</button>
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
