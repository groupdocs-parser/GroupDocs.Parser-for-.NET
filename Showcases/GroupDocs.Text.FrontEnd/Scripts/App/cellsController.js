
app.controller('cellsController', ['$scope', '$http', '$uibModal', '$rootScope', '$uibModalInstance', function ($scope, $http, $uibModal, $rootScope, $uibModalInstance) {
    $scope.rowIndex = "";
    $scope.columnIndex = "";
    //Extract Row from cells
    $scope.extractRow = function () {
        $scope.text.lines = "";
        $http({
            url: "/Cells/ExtractRow",
            method: "GET",
            params: { fileName: $scope.uploadedFile.name, rowIndex: $scope.rowIndex }
        }).then(function successCallback(response) {
            $uibModalInstance.close();
            $scope.text.lines = response.data;
        }, function errorCallback(response) {

        });
    }

    //Extract Columns from cells
    $scope.extractColumn = function () {
        $scope.text.lines = "";
        $http({
            url: "/Cells/ExtractColumn",
            method: "GET",
            params: { fileName: $scope.uploadedFile.name, columnIndex: $scope.columnIndex }
        }).then(function successCallback(response) {
            $uibModalInstance.close();
            $scope.text.lines = response.data;
        }, function errorCallback(response) {

        });
    }
    //Extract Columns from cells
    $scope.extractRowAndColumn = function () {
        $scope.text.lines = "";
        $http({
            url: "/Cells/ExtractRowAndColumn",
            method: "GET",
            params: { fileName: $scope.uploadedFile.name, rowIndex: $scope.rowIndex, columnIndex: $scope.columnIndex }
        }).then(function successCallback(response) {
            $uibModalInstance.close();
            $scope.text.lines = response.data;
        }, function errorCallback(response) {

        });
    }

}]);