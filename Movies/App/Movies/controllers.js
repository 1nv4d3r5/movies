angular.module("MoviesApp")
    .controller("MoviesController", ["$scope", "$movieService", function ($scope, $movieService) {
        $scope.showMovies = function (data) {
            $scope.movies = data;
        }

        $scope.getAll = function () {
            $movieService.getAll($scope.showMovies);
        }

        $scope.delete = function (movie) {
            $movieService.destroy(movie.MovieID, function (data) {
                $scope.movies = $scope.movies.filter(function (m) {
                    return m.MovieID !== movie.MovieID;
                });
            });
        }

        $movieService.getAll($scope.showMovies);
    }])
    .controller("CreateMovieController", ["$scope", "$movieService", function ($scope, $movieService) {
        $scope.movie = {};

        $scope.save = function () {
            $movieService.create($scope.movie, function (data) {
                window.location = "/";
            });
        }
    }])
    .controller("EditMovieController", ["$scope", "$movieService", "$location", function ($scope, $movieService, $location) {
        $scope.showMovie = function (data) {
            $scope.movie = data;
        }

        $scope.save = function () {
            $movieService.update($scope.movie, function (data) {
                window.location = "/";
            });
        }

        var url = $location.absUrl();
        var id = url.substring(url.lastIndexOf("/") + 1);
        $movieService.getByID(id, $scope.showMovie);
    }])
    .controller("MovieDetailsController", ["$scope", "$movieService", "$location", function ($scope, $movieService, $location) {
        $scope.showMovie = function (data) {
            $scope.movie = data;
        }

        $scope.delete = function (movie) {
            $movieService.destroy(movie.MovieID, function (data) {
                window.location = "/";
            });
        }

        var url = $location.absUrl();
        var id = url.substring(url.lastIndexOf("/") + 1);
        $movieService.getByID(id, $scope.showMovie);
    }]);