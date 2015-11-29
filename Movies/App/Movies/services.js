angular.module("MoviesApp")
    .factory("$movieService", ["$http", function ($http) {
        var movieService = {};

        movieService.url = "/api/Movies";
        
        movieService.getAll = function (callback) {
            $http.get(this.url).success(callback);
        }

        movieService.getByID = function (ID, callback) {
            var url =  movieService.url + "/" + ID;
            $http.get(url).success(callback);
        }

        movieService.create = function (movie, callback) {
            $http.post(this.url, movie).success(callback);
        }

        movieService.update = function (movie, callback) {
            $http.put(this.url, movie).success(callback);
        }

        movieService.destroy = function (ID, callback) {
            var url = movieService.url + "/" + ID;
            $http.delete(url, ID).success(callback);
        }
        return movieService;
    }]);