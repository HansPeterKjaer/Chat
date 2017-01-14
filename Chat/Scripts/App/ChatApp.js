app = angular.module('ChatApp', []);
app.controller('ChatController', function ($scope, $http) {
    $scope.name = null;
    $scope.messages = [];

    $scope.loadFeed = function () {
        $http({
            method: 'GET',
            url: '/api/ChatMessages'
        }).success(function (data, status, headers, config) {
            $scope.messages = data;
        }).error(function (data, status, headers, config) {
            // Error handling not implemented yet.
        });
    };
    $scope.loadFeed();

    $scope.checkSession = function () {
        $http({
            method: 'GET',
            url: '/session/getUser'
        }).success(function (data, status) {
            $scope.name = data.user.name;
            $scope.id = data.user.id;
        });
    };
    $scope.checkSession();

    $scope.register = function (name) {
        console.log($scope._name);
        $http({
            method: 'POST',
            url: '/api/ChatUsers',
            data: { 'name': name }
        }).success(function (data, status, headers, config) {
            $scope.name = data.name;
            $scope.id = data.id;

            $http({
                method: 'POST', url: '/session/SetUser', 'data': data
            }).success(function () {
                console.log('session ok');
            });

        }).error(function (data, status, headers, config) {
            // Error handling not implemented yet.
        });
    };

    $scope.submitMessage = function (msg) {
        $http({
            method: 'POST',
            url: 'api/ChatMessages/',
            data: { 'ChatUserId': $scope.id, 'MessageBody': msg }
        }).success(function (data, status, headers, config) {
            $scope.messages.push(data);
        });
    };
});