angular.module('MyApp', ['ngRoute'])
.config(["$routeProvider", function($routeProvider) {
	$routeProvider
		.when('/TrangChu', {
			tenplateUrl: '/Admin/TrangChu/Index.cshtml',
		})
            .when('/TaiKhoan', {
            	tenplateUrl: 'Admin/TaiKhoan/Index.cshtml',
            })
            .when('/Userrole', {
            	tenplateUrl: '/Admin/UserRole/Index.cshtml',
            })
            // $locationProvider.html5Mode(false).hashPrefix('!');
    }]);
// .controller('HomeController', function($scope){

// })
