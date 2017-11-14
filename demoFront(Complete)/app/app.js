
angular.module("myApp", ['ngRoute']);
var app =angular.module("myApp");

app.config(function($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl : "app/wall/myWall.html",
        controller: "MyWallCtrlr"
    });

});

app.component('info-navbar', {
    templateUrl:'/app/layout/navbar.html',
});

