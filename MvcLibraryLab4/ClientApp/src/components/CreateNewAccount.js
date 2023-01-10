import CreateNewAccountForm from "./CreateNewAccountForm";



function CreateNewAccount() {
    async function createNewAccountHandler(newAccountData) {
        const response = await fetch(  // allows to send HTTP requests
            'users',
            {   // second argument is needed for POST request
                method: 'POST',
                body: JSON.stringify(newAccountData)
            }
        );

        console.log(response);
    }

    return (
        <section>
            <h1>Create Account</h1>
            <CreateNewAccountForm onCreateNewAccount={createNewAccountHandler} />
        </section>
    );
}

export default CreateNewAccount;
