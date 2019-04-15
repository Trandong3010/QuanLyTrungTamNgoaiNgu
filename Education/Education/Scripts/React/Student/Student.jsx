'use strict';
class App extends React.Component {
  constructor(props) {
    super(props);
  }
  componentDidMount() {
    $(document).ready(function Load_LstTeacher() {
      $("#dataTable-example").DataTable({
        ajax: {
          url: "/Student/GetStudent",
          type: "post",
          dataType: "json"
        },
        columns: [
          { data: "Name", autowidth: true },
          { data: "Description", autowidth: true },
          { data: "Gender", autowidth: true },
          {
            data: "BirthDay", autowidth: true
            , render: function (data) {
              var jsonDate = data;
              var value = new Date(parseInt(jsonDate.substr(6)));
              var ret = value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear();
              return ret;
            }

          },
          { data: "Address", autowidth: true },
          { data: "Phone", autowidth: true },
          { data: "Email", autowidth: true },
          { data: "Img", autowidth: true }
        ],
        'paging': true,
        'lengthChange': false,
        'searching': true,
        'ordering': false,
        'info': false,
        'responsive': true,
        "scrollY": 500,
      });
    });
  }


  render() {
    return (
        <table className="table table-striped table-bordered table-hover" id="dataTable-example">
          <thead>
            <tr>
              <th>Tên</th>
              <th>Mô tả</th>
              <th>Giới tính</th>
              <th>Ngày sinh</th>
              <th>Địa chỉ</th>
              <th>Điện thoại</th>
              <th>Email</th>
              <th>Hình ảnh</th>
            </tr>
          </thead>
        </table>
    );
  }
} ReactDOM.render(<App />, document.getElementById('root'));