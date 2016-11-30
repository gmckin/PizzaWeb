var app = angular.module('pizzaApp)', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {

  $routProvider.when('/', {
    controller: 'customerController',
    templateUrl: '/app/views/customer.html'
  })
  .otherwise({ redirectTo: '/' });
}]);




//(function (app) {
//  'use strict';

//  app.ngApp = angular.module("pizzaApp", ['ngRoute', 'homeModule']);
//  app.ngApp.config(["$routeProvider", function ($routeProvider) {
//    $routeProvider.when('/home', {
//      templateUrl: "module/home/template.html",
//      controller: "homeCtrl",
//      controllerAs: "home"
//    }).when('/about', {
//      templateUrl: '',
//      controller: "aboutCtrl",
//      controllerAs: 'about'
//    }).otherwise({
//      redirectTo: '/home'
//    });
//  }]);


//})(window.pizzaApp || (window.pizzaApp = {}));


