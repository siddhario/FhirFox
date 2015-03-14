angular.module('patientApp', [])
  .controller('PatientController', ['$scope', '$http', function ($scope, $http) {
      $http.defaults.headers.common['Accept'] = 'application/json+fhir';
      $http.get('../fhir/Patient').
   success(function (data, status, headers, config) {
       $scope.patients = data.entry;       
   }).
   error(function (data, status, headers, config) {
   });
  }]);