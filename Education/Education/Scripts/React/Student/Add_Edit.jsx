class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            data: {},
            Username: '',
            Password: ''
        }
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    onChange(event) {
        const { name, value } = event.target;
        this.setState({ [name]: value });
    }

    handleSubmit() {
        event.preventDefault();
        const { Username, Password } = this.state;
        if (!(Username && Password)) {
            return;
        }
        this.FetchData(Username, Password);
    }

    FetchData(Username, Password) {
        let data = {
            Username: Username,
            Password: Password
        };
        if (Username !== '' && Password !== '') {
            console.log('Username:', Username, 'Password:', Password);

            fetch("", {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                mode: "cors",
                body: JSON.stringify(data)
            })
                .then(response => response.json())
                .then(data => window.location.href = "/Admin/TrangChu/Index")
                .catch(error => console.log(error));


        } else {
            alert('no')
        }
    }

    Open(id) {
        debugger
        if (id == 0) {
            $("#Modal1").modal("show");
            $("#txtUsername").val("");
			$("#txtPassword").val("");
			$("#txtEmail").val("");
        } else {
            
            fetch("/Student/GetStudentsById", {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                mode: "cors",
                body: JSON.stringify(id)
            })
                .then(response => response.json())
                .then(data => this.setState({data: data}))
                .catch(error => console.log(error));
                $("#Modal1").modal("show");
        }
    }

    render() {
        var Username = this.state.Username;
        var Password = this.state.Password;
        console.log(this.state.data);
        return (
            <div className="modal fade" id="Modal1">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header bg-blue">
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                            <h4 className="modal-title">Tài khoản</h4>
                        </div>
                        <div className="modal-body">
                            <form id="Add_Edit_Users">
                                <div className="form-group">
                                    <label htmlFor="inputEmail3" className="col-sm-3 control-label" />
                                    <div className="col-sm-9">
                                        <input type="text" className="form-control hidden" name="ID" id="txtID" />
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div className="form-group">
                                    <label htmlFor="inputEmail3" className="col-sm-3 control-label">Tên đăng nhập</label>
                                    <div className="col-sm-9">
                                        <input type="text" className="form-control hidden" name="ID" id="txtID" />
                                        <input type="text" className="form-control" name="Username" id="txtUsername" placeholder="Nhập tên đăng nhập" />
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div className="form-group">
                                    <label htmlFor="inputPassword3" className="col-sm-3 control-label">Mật khẩu</label>
                                    <div className="col-sm-9">
                                        <input type="password" className="form-control" name="Password" id="txtPassword" placeholder="Nhập mật khẩu" />
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div className="form-group">
                                    <label htmlFor="inputPassword3" className="col-sm-3 control-label">Email</label>
                                    <div className="col-sm-9">
                                        <input type="text" className="form-control" name="Email" id="txtEmail" placeholder="Nhập Email" />
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div className="clearfix" />
                                <div className="form-group">
                                    <button type="submit" className="btn btn-primary pull-right" onclick="Add_Edit()">Lưu</button>
                                    <button type="button" className="btn pull-right btn-danger" data-dismiss="modal">Đóng</button>
                                </div>
                                <br />
                                <br />
                            </form>
                        </div>
                        <div className="modal-footer">
                        </div>
                    </div>
                    {/* /.modal-content */}
                </div>
                {/* /.modal-dialog */}
            </div>
        );
    }
} ReactDOM.render(<App />, document.getElementById('root'));