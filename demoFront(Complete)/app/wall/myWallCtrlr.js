var myApp = angular.module("myApp");


myApp.controller('MyWallCtrlr', function ($scope, $http, WallService) {


    WallService.getPosts()
    .then(function (response) {
        $scope.posts = response.data;

    })
    .catch(function (err) {
        console.log("errorcin");
    });

    $scope.currentPost = {
        title: "",
        description: "",
        teacher: "Pabito Lezcano",
        dateTime: new Date()

    };

    $scope.editPost = {};
   

    $scope.publishPost = function(){
        var newPost = $scope.currentPost;
        WallService.savePost(newPost)
        .then(function(response){
            
            $scope.posts.push(newPost);
            
           WallService.getPosts()
        .then(function (response) {
            $scope.posts = response.data;

        })
        .catch(function (err) {
            console.log("errorcin");
        });

    $scope.currentPost = {
        title: "",
        description: "",
        teacher: "Pabito Lezcano",
        dateTime: new Date()

    };


        })
        .catch(function(err){
            debugger
            console.log(err);
        })
        

    }

    // $scope.updateFeedLocal = function () {
    //     var post = {
    //         Title: $scope.currentPost.Title,
    //         Description: $scope.currentPost.Description,
    //         Teacher: $scope.currentPost.Teacher,
    //         DateTime: new Date().toString()
    //     }
    //     $scope.posts.push(post);
    //     saveInLocalStorage()
    // }

    $scope.deletePostID = function (post, index) {
        WallService.deletePost(post)
        .then(function(response) {
            //$scope.posts.splice(post.id);
            
            $scope.posts.splice(index,1)

            // WallService.getPosts()               // haciendo esto, busca y muestr de nuevo
            // .then(function (response) {          no es efectivo pero para la demo remil anda, y nos aseguramos 
            //     $scope.posts = response.data;    de que ande bien jojo. 
            // })
            // .catch(function (err) {
            //     console.log("errorcin");
            // }); 
            
        })
        .catch(function (err) {
            debugger
            console.log("errorcin");
        }); 

        
    }

    $scope.turnToEditFeedLocal = function (index) { //esta funcion hizo alex, es la que muestra la pantallita
        var toEditPost = $scope.posts[index];       //de edit, creo que aca y en el front esta el tema de que 
        toEditPost.index = index;                   //aparece los cambios directamente atras
        WallService.getPosts()
        .then(function (response) {
        $scope.posts = response.data;

        })
        .catch(function (err) {
           console.log("errorcin");
        });
        $scope.editPost = toEditPost;
        $('.modal').modal('show');
        
        //saveInLocalStorage()
    }


    $scope.editFeedLocal = function () {
        
        var index = $scope.editPost.index
        WallService.updatePost($scope.editPost)
        .then(function(response){
            
            $scope.posts[index] = {
                Title: $scope.editPost.Title,
                Description: $scope.editPost.Description,
                Teacher: $scope.editPost.Teacher,
                DateTime: new Date().toString()
            }

             WallService.getPosts()               // haciendo esto, busca y muestr de nuevo
             .then(function (response) {          //no es efectivo pero para la demo remil anda, y nos aseguramos 
                 $scope.posts = response.data;    //de que ande bien jojo. 
             })
             .catch(function (err) {
                 console.log("errorcin");
             });   

            $('.modal').modal('hide');

        })
        .catch(function(err){
            debugger
            console.log(err);
        })
        
        
    }

    $scope.closeAndReset = function() {
        
        $('.modal').modal('hide');
        
        WallService.getPosts()               // haciendo esto, busca y muestr de nuevo
        .then(function (response) {          //no es efectivo pero para la demo remil anda, y nos aseguramos 
            $scope.posts = response.data;    //de que ande bien jojo. 
        })
        .catch(function (err) {
            console.log("errorcin");
        });   

    } 



});