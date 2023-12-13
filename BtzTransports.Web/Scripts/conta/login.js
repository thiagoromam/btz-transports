(function () {
    var app = angular.module("app");

    app.controller("LoginController", ["$scope", "api", "toastr", function (scope, api, toastr) {

        scope.logar = function () {
            api.conta.login(scope.dados)
                .then(() => window.location.href = "/")
                .catch(r => toastr.error(r.data.message));
        };
    }]);
})();