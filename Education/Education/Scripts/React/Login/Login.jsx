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
			<div className="center-container">
			<div className="main-content-agile">
          <div className="sub-main-w3">
            <div className="wthree-pro">
              <h2>ĐĂNG NHẬP</h2>
            </div>
            <form action="#" method="post" onSubmit={this.handleSubmit}>
              <div className="pom-agile">
                <input value={Username} onChange={(event) => this.onChange(event)} placeholder="Tên đăng nhập" id="Username" name="Username" type="text" className="user" required />
                <span className="icon1"><i className="fa fa-user" aria-hidden="true" /></span>
              </div>
              <div className="pom-agile">
                <input value={Password} onChange={(event) => this.onChange(event)} placeholder="Mật khẩu" id="Password" name="Password" type="Password" className="pass" required />
                <span className="icon2"><i className="fa fa-unlock" aria-hidden="true" /></span>
              </div>
              <div className="sub-w3l">
                <h6><a href="#">Quên mật khẩu?</a></h6>
                <div className="right-w3l">
                  <button type="submit" className="btn btn-success btn-block"><i className="glyphicon glyphicon-log-in" /> Đăng nhập</button>
                </div>
              </div>
            </form>
          </div>
		</div>
		</div>
        );
	}
} ReactDOM.render(<App />, document.getElementById('root'));