app = angular.module('ChatApp', []);
app.controller('ChatController', function ($scope, $http) {
    $scope.name = null;
    $scope.messages = [];

    $scope.register = function (name) {
        console.log($scope._name);
        $http({
            method: 'POST',
            url: '/api/ChatUsers',
            data: { 'name': name }
        }).success(function (data, status, headers, config) {
            $scope.name = data.name;
            $scope.id = data.id;
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