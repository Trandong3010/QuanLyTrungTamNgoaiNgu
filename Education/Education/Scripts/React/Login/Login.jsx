'use strict';
export const Login = user => {
    return axios.post('/Login/CheckValidaUser', {
        Username = user.Username,
        Password = user.Password
    }).then(function (response) {
        console.log(response);
    })
        .catch(function (error) {
            console.log(error);
        });
}
class App extends React.Component {
    constructor(props) {
        this.state = {
            Username: '',
            Password: ''
        }
    }

    onChange(e) {
        this.setState({ [e.target.name]: e.target.value })
    }

    onSubmit(e) {
        e.preventDefault()

        const user = {
            Username: this.state.Username,
            Password: this.state.Password
        }

        Login(user).then(res => {
            if (res) {
                console.log(res)
            }
        })

    }



    render() {
        return (
            <div className="container">
                <div className="row form-container">
                    <div className="col-md-9">
                        <div className="login-panel">
                            <div className="panel-body">
                                <div className="form-group">
                                    <h2 className="panel-title"> TRUNG TÂM NGOẠI NGỮ1 </h2>
                                </div>
                                <form id="loginform" method="post" onsubmit="{this.onSubmit}">
                                    <div id="msgerorr"><ul style={{ color: 'red' }}>Đăng nhập thất bại! Yêu cầu bạn nhập tên đăng nhập và mật khẩu!</ul></div>
                                    <div id="msg"><ul style={{ color: 'red' }}>Tên đăng nhập hoặc mật khẩu không hợp lệ!</ul></div>
                                    <div className="form-group">
                                        <div className="input-group">
                                            <span className="input-group-addon"><i className="glyphicon glyphicon-user" /></span>
                                            <input className="form-control" placeholder="Tên đăng nhập" id="Username" name="Username" type="text" autofocus />
                                            <span id="msgUsername" style={{ color: 'red' }}>Tên đăng nhập chưa tồn tại!</span>
                                        </div>
                                    </div>
                                    <div className="form-group">
                                        <div className="input-group">
                                            <span className="input-group-addon"><i className="glyphicon glyphicon-lock" /></span>
                                            <input className="form-control" placeholder="Mật khẩu" id="Password" name="password" type="Password" defaultValue />
                                        </div>
                                    </div>
                                    <div className="form-group">
                                        <a href><p className="text-right">Quên mật khẩu</p></a>
                                    </div>
                                    <button type="submit" href="index.html" className="btn btn-success btn-block"><i className="glyphicon glyphicon-log-in" /> Đăng nhập</button>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
} ReactDOM.render(<App />, document.getElementById('root'));