'use strict';
class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
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
        // let data = {
        //     Username: Username,
        //     Password: Password
        // };
        // if (Username !== '' && Password !== '') {
        //     console.log('Username:', Username, 'Password:', Password);

        //     fetch("/Login/CheckValidaUser", {
        //         method: 'POST',
        //         headers: {
        //             'Accept': 'application/json',
        //             'Content-Type': 'application/json',
        //         },
        //         mode: "cors",
        //         body: JSON.stringify(data)
        //     })
        //         .then(response => response.json())
        //         .then(data => window.location.href = "/Admin/TrangChu/Index")
        //         .catch(error => console.log(error));


        // } else {
        //     // alert('no')
        // }
        this.FetchData(Username, Password);
    }

    FetchData(Username, Password) {
        let data = {
            Username: Username,
            Password: Password
        };
        if (Username !== '' && Password !== '') {
            console.log('Username:', Username, 'Password:', Password);

            fetch("/Login/CheckValidaUser", {
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


    render() {
        var Username = this.state.Username;
        var Password = this.state.Password;
        return (
            <div className="container">
                <div className="row form-container">
                    <div className="col-md-9">
                        <div className="login-panel">
                            <div className="panel-body">
                                <div className="form-group">
                                    <h2 className="panel-title"> TRUNG TÂM NGOẠI NGỮ </h2>
                                </div>
                                <form method="post"
                                onSubmit={this.handleSubmit}

                                >
                                    <div className="form-group">
                                        <div className="input-group">
                                            <span className="input-group-addon"><i className="glyphicon glyphicon-user" /></span>
                                            <input className="form-control" value={Username} onChange={(event) => this.onChange(event)} placeholder="Tên đăng nhập" id="Username" name="Username" type="text" />
                                        </div>
                                    </div>
                                    <div className="form-group">
                                        <div className="input-group">
                                            <span className="input-group-addon"><i className="glyphicon glyphicon-lock" /></span>
                                            <input className="form-control" value={Password} onChange={(event) => this.onChange(event)} placeholder="Mật khẩu" id="Password" name="Password" type="Password" />
                                        </div>
                                    </div>
                                    <div className="form-group">
                                        <a ><p className="text-right">Quên mật khẩu</p></a>
                                    </div>
                                    <button type="submit" className="btn btn-success btn-block" ><i className="glyphicon glyphicon-log-in" /> Đăng nhập</button>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
} ReactDOM.render(<App />, document.getElementById('root'));