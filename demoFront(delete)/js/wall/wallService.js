angular.module('myApp')
    .factory('WallService', function ($http) {
      var apiUrl = 'http://localhost:59294/'
      return {

        getPosts: function () {
          return $http.get(apiUrl + 'api/Posts')
        },

        savePost: function (post) {
          return $http.post(apiUrl + 'api/Posts', post)
        },

        deletePost: function (post) {
            return $http.delete(apiUrl + 'api/Posts/' + post.id, post.id)
        },

        updatePOst: function (post) {
               // return $http.put(apiUrl + api / posts, post);
        }
      }
    })
