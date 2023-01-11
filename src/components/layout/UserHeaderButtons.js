function VisitorHeaderButtons(props) {
    return (
        <h3 className="d-flex justify-content-center m-3">
          <button className="btn btn-primary m-2 float-start" onClick={props.onLogout}>
                Log out
          </button>
        </h3>
    );
}

export default VisitorHeaderButtons;