angular.module("myApp")
    .factory('WallService', function ($http) {
        var apiUrl = "http://localhost:59294/"
        return {


            getPosts: function () {

                return $http.get(apiUrl + 'api/posts');

            },
            savePost: function (post) {
                return $http.post(apiUrl+'api/posts', post);
            },

            updatePOst: function (post) {
               // return $http.put(apiUrl + api / posts, post);
            }
        }
    });