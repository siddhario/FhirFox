angular.module('patientApp').factory('dataFactory', ['$http', function ($http) {

    var baseUrl = "../fhir/";

    //FHIR CONTENT TYPE INITIALIZATION
    $http.defaults.headers.post['Content-Type'] = 'application/json+fhir';
    $http.defaults.headers.put['Content-Type'] = 'application/json+fhir';
    $http.defaults.headers.common['Accept'] = 'application/json+fhir';

    var factory = {};

    factory.getResources = function (resourceType) {
        return $http.get(baseUrl + resourceType);
    }

    factory.deleteResource = function (resourceType, id) {
        return $http.delete(baseUrl + resourceType + '/' + id);
    }

    factory.updateResource = function (resourceType, id, data) {
        return $http.put(baseUrl + resourceType + '/' + id, data);
    }

    factory.insertResource = function (resourceType, data) {
        return $http.post(baseUrl + resourceType, data);
    }

    factory.prettify = function (json) {
        if (typeof json != 'string') {
            json = JSON.stringify(json, undefined, 2);
        }
        json = json.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
        return json.replace(/("(\\u[a-zA-Z0-9]{4}|\\[^u]|[^\\"])*"(\s*:)?|\b(true|false|null)\b|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?)/g, function (match) {
            var cls = 'number';
            if (/^"/.test(match)) {
                if (/:$/.test(match)) {
                    cls = 'key';
                } else {
                    cls = 'string';
                }
            } else if (/true|false/.test(match)) {
                cls = 'boolean';
            } else if (/null/.test(match)) {
                cls = 'null';
            }
            //return match;
            return '<span class="' + cls + '">' + match + '</span>';
        });
    }

    return factory;

}]);