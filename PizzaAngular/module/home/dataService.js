angular.module('pizzaApp')
.service('dataService', ['$http', function ($http) {

  var urlCustomer = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/Customer";

  this.getCustomers = function () {
    return $http.get(urlCustomer);
  };

  this.getCustomer = function (id) {
    return $http.get(urlCustomer + '/' + id);
  };

  this.insertCustomer = function (cust) {
    return $http.post(urlCustomer, cust);
  };

  this.deleteCustomer = function (id) {
    return $http.delete(urlCustomer, + '/' + id);
  };

  this.getOrders = function (id) {
    return $http.get(urlCustomer + '/' + id + '/orders');
  };

}]);














//(function (app) {
//  'use strict';
//  // app.ngHome = angular.module("homeModule",[])
//  app.ngHome.service('homeSvc', ['$http', function ($http) {
//    var url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/";
//    return {
//      msg: "hello service",
//      get: function (type, id, callback) {
//        var callUrl = url + type + '/' + id;
//        $http.get(callUrl).then(function (res) {
//          console.log(res.data);
//          callback(res.data);
//        }, function (err) {
//          console.log(err);
//        });
//      },
//      post: function () {
//        var callUrl = '';

//        $http.post(callUrl, JSON.stringify(data)).then(function () {

//        }, function (err) {
//          console.log(err);
//        });
//      }
//    }
//  }]);

//  app.ngHome.factory('homeFac', ['$http', function ($http) {
//    return function () {
//      return "hello factory";
//    }
//  }]);

//})(window.pizzaApp);