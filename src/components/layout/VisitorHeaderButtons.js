function VisitorHeaderButtons() {
    return (
        <h3 className="d-flex justify-content-center m-3">
          <button className="btn btn-primary m-2 float-start" data-bs-toggle="modal" data-bs-target="#CreateAccountModal">
            Create Account
          </button>
          <button className="btn btn-primary m-2 float-start" data-bs-toggle="modal" data-bs-target="#LogInModal">
                Log in
          </button>
          <button className="btn btn-primary m-2 float-start" data-bs-toggle="modal" data-bs-target="#LogInAsAdminModal">
                Log in as admin
          </button>
        </h3>
    );
}

export default VisitorHeaderButtons;