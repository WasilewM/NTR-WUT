function LoginForm() {
    return (
        <section>
            <form>
                <div>
                    <label htmlFor='username'>Username</label>
                    <input type='text' required id='username' />
                </div>
                <div>
                    <label htmlFor='password'>Password</label>
                    <input type='password' required id='password' />
                </div>
                <div>
                    <button className="btn btn-light btn-outline-primary">Log in</button>
                </div>
            </form>
        </section>
    );
}

export default LoginForm;
