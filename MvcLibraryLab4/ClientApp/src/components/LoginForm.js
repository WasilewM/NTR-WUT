import classes from './LoginForm.module.css'


function LoginForm() {
    return (
        <section>
            <form className={classes.form}>
                <div className={classes.control}>
                    <label htmlFor='username'>Username</label>
                    <input type='text' required id='username' />
                </div>
                <div className={classes.control}>
                    <label htmlFor='password'>Password</label>
                    <input type='password' required id='password' />
                </div>
                <div className={classes.action}>
                    <button>Log in</button>
                </div>
            </form>
        </section>
    );
}

export default LoginForm;
