import classes from './CreateNewAccountForm.module.css'

import { useRef } from 'react'


function CreateNewAccountForm(props) {
    const usernameInputRef = useRef();
    const firstnameInputRef = useRef();
    const lastnameInputRef = useRef();
    const passwordInputRef = useRef();

    function submitHandler(event) {
        event.preventDefault();     // prevent server request

        const enteredUsername = usernameInputRef.current.value;
        const enteredFirstname= firstnameInputRef.current.value;
        const enteredLastname = lastnameInputRef.current.value;
        const enteredPassword = passwordInputRef.current.value;

        const newAccountData = {
            username: enteredUsername,
            firstname: enteredFirstname,
            lastname: enteredLastname,
            password: enteredPassword
        }

        props.onCreatNewAccount(newAccountData);
    }

    return (
        <section>
            <form className={classes.form} onSubmit={submitHandler}>
                <div className={classes.control}>
                    <label htmlFor='username'>Username</label>
                    <input type='text' required id='username' ref={usernameInputRef} />
                </div>
                <div className={classes.control}>
                    <label htmlFor='firstname'>First Name</label>
                    <input type='text' required id='firstname' ref={firstnameInputRef} />
                </div>
                <div className={classes.control}>
                    <label htmlFor='lastname'>Last Name</label>
                    <input type='text' required id='lastname' ref={lastnameInputRef} />
                </div>
                <div className={classes.control}>
                    <label htmlFor='password'>Password</label>
                    <input type='password' required id='password' ref={passwordInputRef} />
                </div>
                <div className={classes.action}>
                    <button>Create Account</button>
                </div>
            </form>
        </section>
    );
}

export default CreateNewAccountForm;
