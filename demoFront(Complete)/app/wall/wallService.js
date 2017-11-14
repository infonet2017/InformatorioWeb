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

            updatePost: function (post) {
                var indexado = post.id //(post.index) + (1);
               return $http.put(apiUrl + 'api/posts' +"/" + indexado, post);
            },

            deletePost: function (post) {
                var indexado =  post.id// (post.index) + (1);
               return $http.delete(apiUrl + 'api/posts' +"/" + indexado);
            }
        }
    });