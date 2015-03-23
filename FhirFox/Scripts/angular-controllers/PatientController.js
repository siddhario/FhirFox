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

    $scope.buildResource = function () {
        var data = {};

        data["resourceType"] = "Patient";

        if ($scope.Id != null)
            data["id"] = $scope.Id;

        if ($scope.Pin != null)
            data["identifier"] = [{ "system": "http://pin.fhir.com", "value": $scope.Pin }];


        if ($scope.FirstName != null || $scope.LastName != null) {
            var name = {};
            if ($scope.FirstName != null) {
                name["given"] = [$scope.FirstName];
            }
            if ($scope.LastName != null) {
                name["family"] = [$scope.LastName];
            }
            data["name"] = [name];
        }

        if ($scope.Address != null || $scope.City != null) {
            var address = {};
            if ($scope.Address != null)
                address["line"] = [$scope.Address];
            if ($scope.City != null)
                address["city"] = $scope.City;
            data["address"] = address;
        }

        if ($scope.Email != null || $scope.Phone != null) {
            var telecom = [];
            if ($scope.Email != null)
                telecom.push({ "system": "email", "value": $scope.Email });
            if ($scope.Phone != null)
                telecom.push({ "system": "phone", "value": $scope.Phone });
            data["telecom"] = telecom;
        }

        return data;
    }

    //POST DATA FUNCTION
    $scope.submit = function () {

        //FHIR CONTENT TYPE INITIALIZATION
        $http.defaults.headers.post['Content-Type'] = 'application/json+fhir';
        $http.defaults.headers.put['Content-Type'] = 'application/json+fhir';

        var data = $scope.buildResource();

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
        $scope.clearScope();
    }

    $scope.clearScope = function()
    {
        $scope.Id = null;
        $scope.Pin = null;
        $scope.FirstName = null;
        $scope.LastName = null;
        $scope.Address = null;
        $scope.City = null;
        $scope.Phone = null;
        $scope.Email = null;
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

    $scope.prettify = function (json) {
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

    //SELECT DATA FUNCTION
    $scope.select = function (object) {

        var prettyJsonData = $scope.prettify(object);

        document.getElementById("prettyJson").innerHTML = prettyJsonData;

        if ($scope.mode != "ADD") {

            $scope.clearScope();

            $scope.Id = object.id;

            if (object.identifier.length != 0)
                $scope.Pin = object.identifier[0].value;

            if (object.name.length != 0 && object.name[0].given.length != 0)
                $scope.FirstName = object.name[0].given[0];

            if (object.name.length != 0 && object.name[0].family.length != 0)
                $scope.LastName = object.name[0].family[0];

            if (object.address.length != 0 && object.address[0].line.length != 0)
                $scope.Address = object.address[0].line[0];

            if (object.address.length != 0)
                $scope.City = object.address[0].city;

            if (object.telecom != null && object.telecom.length != 0) {
                for (var i = 0; i < object.telecom.length; i++) {
                    var tel = object.telecom[i];
                    if (tel["system"] == "email")
                        $scope.Email = tel.value;

                    if (tel["system"] == "phone")
                        $scope.Phone = tel.value;
                }
            }
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