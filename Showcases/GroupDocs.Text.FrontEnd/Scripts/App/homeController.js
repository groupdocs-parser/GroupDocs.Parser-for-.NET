var app = angular.module('app', ['lr.upload', 'ngSanitize','ui.bootstrap']);
app.controller('homeController', ['$scope', '$http', '$uibModal', '$rootScope', '$q', function ($scope, $http, $uibModal, $rootScope, $q) {
    $scope.text = {};
    $scope.text.lines = "";
    $scope.uploadedFile = {};
    $scope.uploadedFile.name = "";
    $scope.protectedFile = {};
    $scope.protectedFile.password = "";
    fileName = "";
    $scope.metadataEnabled = 'false';
    $scope.cellsEnabled = 'false';
    $scope.wordsEnabled = 'false';
    $scope.statisticsEnabled = 'false';
    $scope.encodingEnabled = 'false';
    $scope.searchEnabled = 'false';
    $scope.highlightEnabled = 'false';
    $scope.myFileName = "";
    $scope.keyWord = "";
   
    //Upload File
    $scope.uploadFile = function (element) {
        $scope.protectedFile.password = "";
        var file = element.files[0];
        fileName = file.name;
        $scope.uploadedFile.name = fileName;
        $scope.myFileName = fileName;
        var uploadUrl = '/Home/Upload';
        //FormData, object of key/value pair for form fields and values
        var fileFormData = new FormData();
        fileFormData.append('file', file);
        var deffered = $q.defer();
        $http.post(uploadUrl, fileFormData, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).success(function (response) {
            EnableOrDisableTools();
            $scope.exrtactText();
        }).error(function (response) {
            deffered.reject(response);
        });
    }
    var EnableOrDisableTools = function () {
        var fileType = fileName.substr(fileName.lastIndexOf('.') + 1)
        $scope.metadataEnabled = 'true';
        $scope.statisticsEnabled = 'true';
        $scope.encodingEnabled = 'true';
        if (fileType == "xls" || fileType == 'xlsx')
        {
            $scope.cellsEnabled = 'true';

        }
        else
        {
            $scope.cellsEnabled = 'false';

        }
           
        if (fileType == "docx" || fileType == "doc")
        {
            $scope.wordsEnabled = 'true';
            $scope.searchEnabled = 'true';
            $scope.highlightEnabled = 'true';
        }
        else
        {
            $scope.wordsEnabled = 'false';
            $scope.searchEnabled = 'false';
            $scope.highlightEnabled = 'false';

        }
          
    }
        
    //Extract Text
    $scope.exrtactText = function () {
        
        $http({
            url: "/Home/ExtractText",
            method: "GET",
            params: { fileName: $scope.uploadedFile.name }
        }).then(function successCallback(response) {
            $scope.text.lines = response.data;
            if ($scope.text.lines[0] == "Invalid password") {
                //open password modal
                var modalInstance = $uibModal.open({
                    templateUrl: '/Content/Modal/PasswordPopup.html',
                    controller: 'passwordController',
                    scope: $scope
                });
            }
        }, function errorCallback(response) {

        });
    }
    //Extract Metadata 
    $scope.extractMetadata = function () {
        $http({
            url: "/Home/ExtractMetadata",
            method: "GET",
            params: { fileName: fileName }
        }).then(function successCallback(response) {
            $scope.text.lines = response.data;
        }, function errorCallback(response) {

        });
    }

    //Extract Table With Format 
    $scope.extractTableWithFormat = function () {
        $http({
            url: "/Home/ExtractTableWithFormat",
            method: "GET",
            params: { fileName: fileName }
        }).then(function successCallback(response) {
            $scope.text.lines = response.data;
        }, function errorCallback(response) {

        });
    }

    //Extract Text With Markdown
    $scope.extractTextWithMarkDown = function () {
        $http({
            url: "/Home/ExtractTextWithMarkDown",
            method: "GET",
            params: { fileName: fileName }
        }).then(function successCallback(response) {
            $scope.text.lines = response.data;
        }, function errorCallback(response) {

        });
    }

    //Extract Document Encoding
    $scope.extractDocumentEndocing = function () {
        $http({
            url: "/Home/ExtractDocumentEndocing",
            method: "GET",
            params: { fileName: fileName }
        }).then(function successCallback(response) {
            $scope.text.lines = response.data;
        }, function errorCallback(response) {

        });
    }

    //Count Word Statistics 
    $scope.countStatistics = function () {
        $http({
            url: "/Home/CountStatistics",
            method: "GET",
            params: { fileName: fileName }
        }).then(function successCallback(response) {
            $scope.text.lines = response.data;
        }, function errorCallback(response) {

        });
    }
   
    //Extract Extract Highlight
    $scope.extractExtractHighlight = function () {
        $http({
            url: "/Home/ExtractHighlight",
            method: "GET",
            params: { fileName: fileName }
        }).then(function successCallback(response) {
            $scope.text.lines = response.data;
        }, function errorCallback(response) {

        });
    }

    //open rows modal
    $scope.open = function () {
        var modalInstance = $uibModal.open({
            templateUrl: '/Content/Modal/popup.html',
            controller: 'cellsController',
            scope: $scope
        });
    }

    //open rows modal
    $scope.openColumnsPopup = function () {
        var modalInstance = $uibModal.open({
            templateUrl: '/Content/Modal/ColumnsPopup.html',
            controller: 'cellsController',
            scope: $scope
        });
    }

    //open row and column modal
    $scope.openRowAndColumnPopup = function () {
        var modalInstance = $uibModal.open({
            templateUrl: '/Content/Modal/RowAndColumnPopup.html',
            controller: 'cellsController',
            scope: $scope
        });
    }
    //open search modal
    $scope.openSearchPopup = function () {
        var modalInstance = $uibModal.open({
            templateUrl: '/Content/Modal/SearchPopup.html',
            controller: 'searchController',
            scope: $scope
        });
    }
}]);
app.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);
    
