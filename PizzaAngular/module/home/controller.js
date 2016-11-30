//(function (app) {
//  'use strict';
//  app.ngHome = angular.module("homeModule", []);
//  app.ngHome.controller('homeCtrl', ['homeFac', 'homeSvc', function (homeFac, homeSvc) {
//    var that = this;

//    that.hello = "hello home";
//    that.facto = homeFac();
//    that.servi = homeSvc.msg;

//    homeSvc.get('customer', Math.round((Math.random() * 9) + 1), function () {
//      that.swapi = data.name;
//    });
//  }]);

//})(window.pizzaApp);




(function () {

  var injectParams = ['$scope', 'dataFactory'];
  var CustomerController = function ($scope, dataFactory) {

    $scope.status;
    $scope.customers;
    $scope.orders;

    getCustomers();

    function getCustomers() {
      dataFactory.getCustomers()
          .success(function (custs) {
            $scope.customers = custs;
          })
          .error(function (error) {
            $scope.status = 'Unable to load customer data: ' + error.message;
          });
    }

   

    $scope.insertCustomer = function () {
      //Fake customer data
      var cust = {
        ID: 10,
        FirstName: 'JoJo',
        LastName: 'Pikidily'
      };
      dataFactory.insertCustomer(cust)
          .success(function () {
            $scope.status = 'Inserted Customer! Refreshing customer list.';
            $scope.customers.push(cust);
          }).
          error(function (error) {
            $scope.status = 'Unable to insert customer: ' + error.message;
          });
    };

    $scope.deleteCustomer = function (id) {
      dataFactory.deleteCustomer(id)
      .success(function () {
        $scope.status = 'Deleted Customer! Refreshing customer list.';
        for (var i = 0; i < $scope.customers.length; i++) {
          var cust = $scope.customers[i];
          if (cust.ID === id) {
            $scope.customers.splice(i, 1);
            break;
          }
        }
        $scope.orders = null;
      })
      .error(function (error) {
        $scope.status = 'Unable to delete customer: ' + error.message;
      });
    };

    $scope.getCustomerOrders = function (id) {
      dataFactory.getOrders(id)
      .success(function (orders) {
        $scope.status = 'Retrieved orders!';
        $scope.orders = orders;
      })
      .error(function (error) {
        $scope.status = 'Error retrieving customers! ' + error.message;
      });
    };
  };

  CustomerController.$inject = injectParams;

  angular.module('pizzaApp').controller('customerController', CustomersController);

}());