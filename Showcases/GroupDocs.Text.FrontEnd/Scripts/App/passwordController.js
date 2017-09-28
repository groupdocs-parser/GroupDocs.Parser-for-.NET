
app.controller('passwordController', ['$scope', '$http', '$uibModal', '$rootScope', '$uibModalInstance', function ($scope, $http, $uibModal, $rootScope, $uibModalInstance) {
    //Extract protected Document
    $scope.extractProtectedDocument = function () {
        $scope.text.lines = "";
        $http({
            url: "/Home/ExtractText",
            method: "GET",
            params: { fileName: $scope.uploadedFile.name, password: $scope.protectedFile.password }
        }).then(function successCallback(response) {
            $uibModalInstance.close();
            $scope.text.lines = response.data;
        }, function errorCallback(response) {

        });
    }

}]);