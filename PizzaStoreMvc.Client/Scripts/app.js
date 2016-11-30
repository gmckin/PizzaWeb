var pizzaApp = angular.modult('pizzaApp', []);

pizzaApp.controller('crustController', function ($scope, $http) {
  var url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/crust";
  $http.get(url)
  .success(function (result) {
    $scope.crustOptions = result;
  })
  .error(function (data) {
    console.log(data);
  });
});