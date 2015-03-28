angular.module('patientApp').factory('dataFactory', ['$http', function ($http) {

    var url = "../fhir/Patient/";

    var factory = {};

    $http.defaults.headers.common['Accept'] = 'application/json+fhir';

    factory.getPatients = function () {
        return $http.get(url);
    }

    return factory;

}]);