angular.module('patientApp').controller('PatientController', ['$scope', 'dataFactory', function ($scope, dataFactory) {

    function init() {
        $scope.resourceType = 'Patient';
        $scope.mode = "READ";
        loadData();
    }

    init();  

    /* VIEW MODEL MAPPING*/
    $scope.select = function (object) {

        var prettyJsonData = dataFactory.prettify(object);

        $("#prettyJson").html(prettyJsonData);        

        if ($scope.mode != "ADD") {

            $scope.form = {};

            $scope.form.Id = object.id;

            if (object.identifier.length != 0)
                $scope.form.Pin = object.identifier[0].value;

            if (object.name.length != 0 && object.name[0].given.length != 0)
                $scope.form.FirstName = object.name[0].given[0];

            if (object.name.length != 0 && object.name[0].family.length != 0)
                $scope.form.LastName = object.name[0].family[0];

            if (object.address.length != 0 && object.address[0].line.length != 0)
                $scope.form.Address = object.address[0].line[0];

            if (object.address.length != 0)
                $scope.form.City = object.address[0].city;

            if (object.telecom != null && object.telecom.length != 0) {
                for (var i = 0; i < object.telecom.length; i++) {
                    var tel = object.telecom[i];
                    if (tel["system"] == "email")
                        $scope.form.Email = tel.value;

                    if (tel["system"] == "phone")
                        $scope.form.Phone = tel.value;
                }
            }
        }
    }

    $scope.buildResource = function () {
        var data = {};

        data["resourceType"] = "Patient";

        if ($scope.form.Id != null)
            data["id"] = $scope.form.Id;

        if ($scope.form.Pin != null)
            data["identifier"] = [{ "system": "http://pin.fhir.com", "value": $scope.form.Pin }];


        if ($scope.form.FirstName != null || $scope.form.LastName != null) {
            var name = {};
            if ($scope.form.FirstName != null) {
                name["given"] = [$scope.form.FirstName];
            }
            if ($scope.form.LastName != null) {
                name["family"] = [$scope.form.LastName];
            }
            data["name"] = [name];
        }

        if ($scope.form.Address != null || $scope.form.City != null) {
            var address = {};
            if ($scope.form.Address != null)
                address["line"] = [$scope.form.Address];
            if ($scope.form.City != null)
                address["city"] = $scope.form.City;
            data["address"] = address;
        }

        if ($scope.form.Email != null || $scope.form.Phone != null) {
            var telecom = [];
            if ($scope.form.Email != null)
                telecom.push({ "system": "email", "value": $scope.form.Email });
            if ($scope.form.Phone != null)
                telecom.push({ "system": "phone", "value": $scope.form.Phone });
            data["telecom"] = telecom;
        }

        return data;
    }
    /* VIEW MODEL MAPPING*/

    /*STATE CHANGES*/
    $scope.add = function () {
        $scope.mode = "ADD";
        $scope.form = {};
    }

    $scope.update = function (data) {
        $scope.select(data);
        $scope.mode = "UPDATE";
    }

    $scope.cancel = function () {
        $scope.mode = "READ";
    }

    $scope.setCurrent = function (currentObject) {
        $scope.current = currentObject;
    }
    /*STATE CHANGES*/

    /*DATA MANAGMENT*/
    $scope.submit = function () {

        var data = $scope.buildResource();

        if ($scope.mode == "UPDATE") {
            dataFactory.updateResource($scope.resourceType, $scope.form.Id, data)
                .success(function (data, status, headers, config) {
                    loadData();
                }).
                error(function (data, status, headers, config) {
                    alert(data.text.div);
                });
        }
        else if ($scope.mode == "ADD") {
            dataFactory.insertResource($scope.resourceType, data)
                .success(function (data, status, headers, config) {
                    loadData();
                }).
                error(function (data, status, headers, config) {
                    alert(data.text.div);
                });
        };
    };

    $scope.delete = function (object) {
        dataFactory.deleteResource($scope.resourceType, object.id);
        success(function (data, status, headers, config) {
            loadData();
        }).
        error(function (data, status, headers, config) {
            alert(data.text.div);
        });
    }

    function loadData() {
        dataFactory.getResources($scope.resourceType)
            .success(function (pats) {
                $scope.patients = pats.entry;
            })
            .error(function (error) {
                $scope.status = 'Unable to load patient data: ' + error.message;
            });
    }
    /*DATA MANAGMENT*/
   
}]);

