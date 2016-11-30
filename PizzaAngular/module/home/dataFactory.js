angular.module('pizzaApp')
.factory('dataFactory', ['$http', function ($http) {

  var urlCustomer = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/Customer";
  var dataFactory = {};

  dataFactory.getCustomers = function () {
    return $http.get(urlCustomer);
  };

  dataFactory.getCustomer = function (id) {
    return $http.get(urlCustomer + '/' + id);
  };

  dataFactory.insertCustomer = function (cust) {
    return $http.post(urlCustomer, cust);
  };

  dataFactory.deleteCustomer = function (id) {
    return $http.delete(urlCustomer, + '/' + id);
  };

  dataFactory.getOrders = function (id) {
    return $http.get(urlCustomer + '/' + id + '/orders');
  };

  return dataFactory;
}]);