var apiUrl = "http://localhost:59294/";

angular.module("myApp", []);
var app =angular.module("myApp");

app.filter('textToLink', function ($sce) {
    var urlPattern = /(http|ftp|https):\/\/[\w-]+(\.[\w-]+)+([\w.,@?^=%&amp;:\/~+#-]*[\w@?^=%&amp;\/~+#-])?/gi;
    return function (text) {
        var htmlData = text.replace(urlPattern,
            '<a target="_blank" href="$&">$&</a>');
        return $sce.trustAsHtml(htmlData);
    };
});

app.controller('myWall', ['$scope', '$http', function ($scope, $http) {

                $scope.posts = (localStorage.getItem('posts')!==null) ? JSON.parse(localStorage.getItem('posts')) : [];

                $scope.currentPost = {
                      Title: "",
                      Description : "",
                      Teacher : "Pabito Lezcano",
                      DateTime: new Date().toString()

                };

                $scope.editPost = { };

                $scope.updateFeedLocal = function(){
                    var post = {
                         Title: $scope.currentPost.Title,
                          Description : $scope.currentPost.Description,
                          Teacher : $scope.currentPost.Teacher,
                          DateTime: new Date().toString()
                    }
                    $scope.posts.push(post);
                    saveInLocalStorage ()
                }

                $scope.deleteFeedLocal = function(index){
                    $scope.posts.splice(index,1);
                    saveInLocalStorage ()
                }

                $scope.turnToEditFeedLocal = function(index){
                    var toEditPost = $scope.posts[index];
                    toEditPost.index = index;
                    $scope.editPost = toEditPost;
                    $('.modal').modal('show');
                    saveInLocalStorage ()
                }


                $scope.editFeedLocal = function(){
                    var index = $scope.editPost.index
                    $scope.posts[index] = {
                             Title: $scope.editPost.Title,
                          Description : $scope.editPost.Description,
                          Teacher : $scope.editPost.Teacher,
                          DateTime: new Date().toString()
                    }
                    $('.modal').modal('hide');
                    saveInLocalStorage ()
                }

                function saveInLocalStorage (){
                    localStorage.setItem('posts', JSON.stringify($scope.posts));
                }







                // document.getElementById('updateBox').focus();
               // $http.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
          /**      $http({
                    method: "POST",
                    url: "http://localhost:5000/api/posts/",
                    data : {
                      ID: int,
                      Title: string,
                      Description : string,
                      Teacher : string,
                      DateTime: DateTime,

                    }
                }).then(function (response) {
                    $scope.updatesData = response.data.updates;
                });
                **/
                $scope.commentForm = {};
                $scope.commentToggle = function (index) {
                    $scope.commentForm[index] = !$scope.commentForm[index];
                    $timeout(function () {
                        document.getElementById('commenInput' + index).focus();
                    }, 200);
                }
                $scope.updateFeed = function () {
                    if ($scope.feedValue) {
                       
                        $http({
                            method: "POST",
                            url: apiUrl+ "api/posts/",
                            data:{
                                Title: "holis soy un titulo",
                                Description : $scope.feedValue,
                                Teacher : "holis soy un ticher"
                               // "DateTime": "soy una fecha"
                            } /*'user_update=' + $scope.feedValue*/
                        }).then(function (response) {
							debugger
                            $scope.updatesData.unshift(response.data.updates[0]);
                            $scope.feedValue = "";
                            document.getElementById('updateBox').focus();
                        })
                        .catch(function(error){ 
                             console.log(error)
                         }); 
                    }
                }
                $scope.deleteFeed = function (ID, index) {
                    if (ID > 0) {
                        $http({
                            method: "POST",
                            url: "http://localhost:5000/api/posts/",
                            data: 'ID=' + ID
                        }).then(function (response) {
                            if (response) {
                                $scope.updatesData.splice(index, 1);
                            }
                        });
                    }
                }
                // $scope.updateComment = function (commentSubmitData, index, ID) {
                //     if (commentSubmitData.commentValue) {
                //         $http({
                //             method: "POST",
                //             url: "http://localhost:5000/api/posts/",
                //             data: 'ID=' + ID + '&user_comment=' + commentSubmitData.commentValue
                //         }).then(function (response) {
                //             $scope.updatesData[index].comments.push(response.data.comments[0]);
                //             commentSubmitData.commentValue = '';
                //             document.getElementById('commenInput' + index).focus();
                //         });
                //     }
                // }
                // $scope.deleteComment = function (commentIndex, parentIndex, ID, commentID) {
                //     if (updateID > 0) {
                //         $http({
                //             method: "POST",
                //             url: "BorrarComentario NUESTRA APIS",
                //             data: 'updateID=' + ID + '&commentID=' + commentID
                //         }).then(function (response) {
                //             if (response) {
                //                 $scope.updatesData[parentIndex].comments.splice(commentIndex, 1);
                //             }
                //         });
                //     }
                // }


}]);