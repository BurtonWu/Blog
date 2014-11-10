angular.module('testApp', [])
    .factory('testFactory', function () {
        var secretData = ['num1', 'num2'];
        factoryObj = {};
        factoryObj.secrets = {
            get: function () { return secretData; },
            set: function (data) { secretData.push(data); }
        };
        factoryObj.testFunction = function (message) { return message + " testFunction"; }
        return factoryObj;
    })
    .filter('reverse', function () {
        return function(text)
        {
            return text.split("").reverse().join("");
        }
    })
    .controller('testCtor', ['$scope','testFactory',function ($scope, testFactory) {
        $scope.data = {
            message: 'hello',
            func2 : function() { return "func2"; }
        }
    }])
    