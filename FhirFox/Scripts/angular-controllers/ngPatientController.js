angular.module('patientApp', [])
  .controller('PatientController', ['$scope', '$http', function ($scope, $http) {

      $scope.submit = function () {
          $http.defaults.headers.post['Content-Type'] = 'application/json+fhir';
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

          $http.post('/../fhir/Patient', data).
   success(function (data, status, headers, config) {
       alert('OK');
   }).
   error(function (data, status, headers, config) {
       alert('ERROR');
   });

      };

      $http.defaults.headers.common['Accept'] = 'application/json+fhir';
      $http.get('../fhir/Patient').
   success(function (data, status, headers, config) {
       $scope.patients = data.entry;
   }).
   error(function (data, status, headers, config) {
   });
  }]);