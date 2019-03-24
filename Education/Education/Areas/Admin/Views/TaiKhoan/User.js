function ConTroller_User()
{
	function ShowEdit(t) {
		$("#Modal1").modal("show");
		if (t != 0) {
			$.ajax({
				url: "/TaiKhoan/GetUsersById?id=" + t,
				type: "GET",
				datatype: "JSON",
				success: function (value) {
					var obj = JSON.parse(value);
					$("#txtUsername").val(obj.Name);
					$("#txtPassword").val(obj.Name);
					$("#txtEmail").val(obj.Name);
				}
			});
		}

	};
}