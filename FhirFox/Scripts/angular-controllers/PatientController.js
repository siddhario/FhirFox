// Code goes here

var myApp = angular.module('patientApp', ['angularUtils.directives.dirPagination']);

function PatientController($scope, $http) {

    var url = "../fhir/Patient/";
    $scope.mode = "READ";


    $scope.currentPage = 1;
    $scope.pageSize = 10;
    $scope.patients = [];



    $scope.pageChangeHandler = function (num) {
        console.log('meals page changed to ' + num);
    };


    // LOAD DATA FUNCTION
    $scope.loadData = function () {
        $http.defaults.headers.common['Accept'] = 'application/json+fhir';
        $http.get(url).
     success(function (data, status, headers, config) {
         //IF OK BIND DATA TO VIEW MODEL
         $scope.patients = data.entry;
         $scope.mode = "READ";
     }).
     error(function (data, status, headers, config) {
         //IF NOT SHOW ERROR
         alert(data.text.div);
     });
    };


    //POST DATA FUNCTION
    $scope.submit = function () {

        //FHIR CONTENT TYPE INITIALIZATION
        $http.defaults.headers.post['Content-Type'] = 'application/json+fhir';
        $http.defaults.headers.put['Content-Type'] = 'application/json+fhir';



        //COLLECTING DATA INTO FHIR RESOURCE
        var data = {
            "resourceType": "Patient",
            "id": $scope.Id,
            "name": [
                  {
                      "family": [$scope.LastName],
                      "given": [$scope.FirstName]
                  }],
            "address": [
                {
                    "line": [$scope.Address]
                    , "city": $scope.City
                }]
        };

        if ($scope.mode == "MODIFY") {
            //POSTING DATA
            $http.put(url + $scope.Id, data).
     success(function (data, status, headers, config) {
         //RELOAD DATA ON SUCCESSFULL POST
         $scope.loadData();
     }).
     error(function (data, status, headers, config) {
         //SHOW ERROR ON FAILED POST
         alert(data.text.div);
     });
        }
        else if ($scope.mode == "ADD") {
            //POSTING DATA
            $http.post(url, data).
      success(function (data, status, headers, config) {

          //RELOAD DATA ON SUCCESSFULL POST
          $scope.loadData();
      }).
      error(function (data, status, headers, config) {
          //SHOW ERROR ON FAILED POST
          alert(data.text.div);
      });
        };
    };



    $scope.add = function () {
        $scope.mode = "ADD";
        $scope.Id = null;
        $scope.FirstName = null;
        $scope.LastName = null;
        $scope.Address = null;
        $scope.City = null;
    }



    //DELETE DATA FUNCTION
    $scope.remove = function (object) {
        $http.delete(url + object.id).
     success(function (data, status, headers, config) {
         //IF OK RELOAD DATA
         $scope.loadData();
     }).
     error(function (data, status, headers, config) {
         //IF NOT SHOW ERROR
         alert(data.text.div);
     });
    }


    //SELECT DATA FUNCTION
    $scope.select = function (object) {
        if ($scope.mode != "ADD") {
            $scope.Id = object.id;
            $scope.FirstName = object.name[0].given[0];
            $scope.LastName = object.name[0].family[0];
            $scope.Address = object.address[0].line[0];
            $scope.City = object.address[0].city;
        }
    }

    $scope.modify = function (object) {
        $scope.select(object);
        $scope.mode = "MODIFY";
    }



    $scope.isDisabled = function () {
        return $scope.mode == "READ";
    };


    $scope.cancel = function () {
        $scope.mode = "READ";
    }

    $scope.setCurrent = function (currentObject) {
        $scope.current = currentObject;
    }


    $scope.loadData();


}

function OtherController($scope) {
    $scope.pageChangeHandler = function (num) {
        console.log('going to page ' + num);
    };
}

myApp.controller('PatientController', PatientController);
myApp.controller('OtherController', OtherController);