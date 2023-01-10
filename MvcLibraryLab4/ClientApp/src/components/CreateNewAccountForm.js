import classes from './CreateNewAccountForm.module.css'


function CreateNewAccountForm() {
    return (
        <section>
            <form className={classes.form}>
                <div className={classes.control}>
                    <label htmlFor='username'>Username</label>
                    <input type='text' required id='username' />
                </div>
                <div className={classes.control}>
                    <label htmlFor='firstname'>First Name</label>
                    <input type='text' required id='firstname' />
                </div>
                <div className={classes.control}>
                    <label htmlFor='lastname'>Last Name</label>
                    <input type='text' required id='lastname' />
                </div>
                <div className={classes.control}>
                    <label htmlFor='password'>Password</label>
                    <input type='password' required id='password' />
                </div>
                <div className={classes.action}>
                    <button>Create Account</button>
                </div>
            </form>
        </section>
    );
}

export default CreateNewAccountForm;
