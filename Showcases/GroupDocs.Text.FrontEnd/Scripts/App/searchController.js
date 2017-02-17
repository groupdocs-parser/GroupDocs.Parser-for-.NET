
app.controller('searchController', ['$scope', '$http', '$uibModal', '$rootScope', '$uibModalInstance', function ($scope, $http, $uibModal, $rootScope, $uibModalInstance) {
    //Extract protected Document
    $scope.searchText = function () {
        $scope.text.lines = "";
        $http({
            url: "/Search/SearchText",
            method: "GET",
            params: { fileName: $scope.uploadedFile.name, keyWord: $scope.keyWord }
        }).then(function successCallback(response) {
            $uibModalInstance.close();
            $scope.text.lines = response.data;
        }, function errorCallback(response) {

        });
    }

}]);