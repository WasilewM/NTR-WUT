import CreateNewAccountForm from "./CreateNewAccountForm";


function CreateNewAccount() {
    async function createNewAccountHandler(newAccountData) {
        const response = await fetch(  // allows to send HTTP requests
            'users/add',
            {   // second argument is needed for POST request
                method: 'POST',
                body: JSON.stringify(newAccountData),
                headers: { 'Content-type': 'application/json' }
            }
        );

        console.log(response);
    }

    return (
        <div>
            <h2>Create Account</h2>
            <CreateNewAccountForm onCreateNewAccount={createNewAccountHandler} />
        </div>
    );
}

export default CreateNewAccount;
