
angular.module("myApp", ['ngRoute']);
var app =angular.module("myApp");

app.config(function($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl : "js/wall/myWall.html",
        controller: "MyWallCtrlr"
    });
    
});

